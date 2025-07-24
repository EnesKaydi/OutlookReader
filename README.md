# Web Outlook Mail Okuyucu

Bu proje, bir Outlook Veri Dosyasını (.pst) web arayüzü üzerinden okumanıza ve içerisindeki e-postalarda arama yapmanıza olanak tanıyan basit bir ASP.NET Core Razor Pages uygulamasıdır.

## Projenin Amacı

Uygulamanın temel amacı, büyük boyutlu `.pst` dosyalarını bir sunucu veya bilgisayar üzerinde açmadan, doğrudan web tarayıcısı üzerinden yükleyerek, gönderen veya e-posta içeriğine göre hızlıca filtreleyip arama yapabilmektir.

## Gereksinimler

Uygulamayı geliştirmek ve çalıştırmak için Windows bilgisayarınızda aşağıdaki araçların kurulu olması gerekmektedir:

-   [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) veya üstü
-   [JetBrains Rider](https://www.jetbrains.com/rider/) IDE

## Kurulum ve Çalıştırma

Aşağıdaki adımları takip ederek projeyi JetBrains Rider üzerinde kolayca ayağa kaldırabilirsiniz:

1.  **Projeyi Açın:**
    -   Proje dosyalarını bilgisayarınıza indirin veya klonlayın.
    -   JetBrains Rider'ı başlatın.
    -   `File -> Open -> Open Solution or Project` menüsünden projenin kök dizinindeki `WebOutlookRead.sln` çözüm dosyasını seçerek açın.

2.  **Bağımlılıkları Yükleyin:**
    -   Rider, projeyi açtığınızda gerekli olan NuGet paketlerini (`PSTParse` vb.) otomatik olarak algılayıp geri yükleyecektir.
    -   Eğer paketler otomatik yüklenmezse, `Solution Explorer` penceresinde çözüme sağ tıklayıp **"Restore NuGet Packages"** seçeneğini seçerek işlemi manuel olarak başlatabilirsiniz.

3.  **Uygulamayı Çalıştırın:**
    -   Rider arayüzünün sağ üst köşesinde bulunan yeşil **"Run" (►)** butonuna tıklayın.
    -   Rider, projeyi derleyecek, web sunucusunu başlatacak ve varsayılan tarayıcınızda uygulamayı otomatik olarak açacaktır.

## Nasıl Kullanılır?

Uygulama tarayıcıda açıldığında:

1.  **Dosya Seçin:** "Select Outlook Data File (.pst)" etiketli butona tıklayarak bilgisayarınızdan bir `.pst` dosyası seçin.
2.  **Arama Kriteri Girin (İsteğe Bağlı):**
    -   **From:** E-postaları gönderen kişiye göre filtrelemek için bu alanı doldurun.
    -   **Content:** E-posta konusu veya içeriğine göre arama yapmak için bu alanı doldurun.
3.  **Aramayı Başlatın:** "Search Emails" butonuna tıklayarak işlemi başlatın.
4.  **Sonuçları Görüntüleyin:** Arama tamamlandığında, eşleşen e-postalar sayfanın alt kısmında bir tablo halinde listelenecektir.

**Not:** Yüklenen `.pst` dosyasının boyutuna bağlı olarak arama işleminin süresi değişiklik gösterebilir. Lütfen büyük dosyalarda sabırla bekleyiniz. 