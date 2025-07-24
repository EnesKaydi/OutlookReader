using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PSTParse; // PSTParse kütüphanesini ekliyoruz
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace WebOutlookRead.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        SearchResults = new List<EmailResult>();
    }

    public List<EmailResult> SearchResults { get; set; }

    public void OnGet()
    {
    }

    public void OnPost(IFormFile pstFile, string sender, string content)
    {
        if (pstFile == null || pstFile.Length == 0)
        {
            // Dosya seçilmediyse bir hata mesajı gösterebiliriz.
            // Şimdilik sadece geri dönüyoruz.
            return;
        }

        try
        {
            // Yüklenen dosyayı geçici bir konuma kaydediyoruz.
            var tempPath = Path.GetTempFileName();
            using (var stream = new FileStream(tempPath, FileMode.Create))
            {
                pstFile.CopyTo(stream);
            }

            // PST dosyasını açıyoruz.
            using (var pst = new PSTFile(tempPath))
            {
                var stack = new Stack<MailFolder>();
                stack.Push(pst.TopOfPST);
                while (stack.Count > 0)
                {
                    var folder = stack.Pop();

                    foreach (var child in folder.SubFolders)
                    {
                        stack.Push(child);
                    }

                    foreach (dynamic email in folder.GetIpmItems())
                    {
                        bool matches = true;

                        // Gönderen'e göre arama
                        if (!string.IsNullOrEmpty(sender))
                        {
                            string senderName = email.SenderName ?? "";
                            string senderEmail = email.SenderEmailAddress ?? "";
                            if (!senderName.Contains(sender, System.StringComparison.OrdinalIgnoreCase) &&
                                !senderEmail.Contains(sender, System.StringComparison.OrdinalIgnoreCase))
                            {
                                matches = false;
                            }
                        }

                        // İçeriğe göre arama
                        if (matches && !string.IsNullOrEmpty(content))
                        {
                            string subject = email.Subject ?? "";
                            string body = email.Body ?? "";
                            if (!subject.Contains(content, System.StringComparison.OrdinalIgnoreCase) &&
                                !body.Contains(content, System.StringComparison.OrdinalIgnoreCase))
                            {
                                matches = false;
                            }
                        }

                        if (matches)
                        {
                            SearchResults.Add(new EmailResult
                            {
                                From = email.SenderName,
                                To = email.DisplayTo,
                                Subject = email.Subject,
                                Body = email.Body,
                                SentDate = email.ClientSubmitTime
                            });
                        }
                    }
                }
            }

            // Geçici dosyayı siliyoruz.
            System.IO.File.Delete(tempPath);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Error processing PST file.");
            // Hata durumunda kullanıcıya bir mesaj gösterebiliriz.
        }
    }
}

public class EmailResult
{
    public string? From { get; set; }
    public string? To { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
    public System.DateTime? SentDate { get; set; }
}