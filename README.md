# Web Outlook Mail Okuyucu

Bu proje, bir Outlook Veri Dosyasını (.pst) web arayüzü üzerinden okumanıza ve içerisindeki e-postalarda arama yapmanıza olanak tanıyan basit bir ASP.NET Core Razor Pages uygulamasıdır.

## Projenin Amacı

Uygulamanın temel amacı, büyük boyutlu `.pst` dosyalarını bir sunucu veya bilgisayar üzerinde açmadan, doğrudan web tarayıcısı üzerinden yükleyerek, gönderen veya e-posta içeriğine göre hızlıca filtreleyip arama yapabilmektir.

## Gereksinimler

Uygulamayı geliştirmek ve çalıştırmak için Windows bilgisayarınızda aşağıdaki araçların kurulu olması gerekmektedir:

-   [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) veya üstü
-   [JetBrains Rider](https://www.jetbrains.com/rider/) IDE

## Kurulum ve Çalıştırma (Adım Adım Detaylı Anlatım)

Bu bölüm, projeyi daha önce hiç .NET veya Rider kullanmamış birinin bile kolayca çalıştırabilmesi için hazırlanmıştır.

### Adım 1: Proje Dosyalarını Hazırlama

Öncelikle, projenin kodlarını bilgisayarınıza almanız gerekiyor. Eğer kodlar bir `.zip` dosyası olarak size verildiyse, dosyayı bir klasöre çıkartın.

### Adım 2: Projeyi Rider'da Açma

Rider, bizim kod yazma ve projemizi yönetme aracımızdır (IDE).

1.  Masaüstünüzdeki veya Başlat menüsündeki **JetBrains Rider** ikonuna tıklayarak programı başlatın.
2.  Karşınıza gelen başlangıç ekranında veya sol üstteki menüde `File` (Dosya) seçeneğini bulun.
3.  `File -> Open -> Open Solution or Project` (Dosya -> Aç -> Çözüm veya Proje Aç) yolunu izleyin.
4.  Bir dosya seçme penceresi açılacaktır. Bu pencerede, Adım 1'de hazırladığınız proje klasörünün içine gidin.
5.  Klasörün içinde `WebOutlookRead.sln` adında bir dosya göreceksiniz. Bu dosya, projemizin ana dosyasıdır ve tüm proje yapısını bir arada tutar. Bu dosyayı seçin ve "Open" (Aç) butonuna tıklayın.

### Adım 3: Gerekli Paketlerin Yüklenmesi (Projenin Beyni)

Projemiz, `.pst` dosyalarını okumak gibi özel işlevleri yerine getirmek için dışarıdan hazır kod paketleri kullanır. Bunlara "NuGet paketi" denir. Rider bu paketleri bizim için internetten bulup projeye dahil eder.

1.  Projeyi açtığınızda Rider genellikle ekranın sağ altında veya üstünde bu paketleri otomatik olarak indirmeye başlar. Bu işleme "restore" (geri yükleme) denir. Birkaç saniye veya dakika sürebilir.
2.  Eğer otomatik olarak başlamazsa veya bir sorun olduğunu düşünüyorsanız, işlemi elle tetikleyebilirsiniz:
    -   Rider'da sol tarafta projenin dosyalarını gösteren `Solution Explorer` (Çözüm Gezgini) panelini bulun.
    -   En üstte, çözümün adı olan `Solution 'WebOutlookRead'` yazar. Buna sağ tıklayın.
    -   Açılan menüden **"Restore NuGet Packages"** (NuGet Paketlerini Geri Yükle) seçeneğini bulun ve tıklayın. Bu işlem, projenin ihtiyaç duyduğu tüm ek kütüphaneleri indirecektir.

### Adım 4: Uygulamayı Başlatma ve Test Etme

Artık her şey hazır. Projemizi çalıştırıp web sitesini görme zamanı.

1.  Rider penceresinin sağ üst köşesine bakın. Orada yeşil renkli bir **"Run" (Çalıştır)** butonu (genellikle bir oynat (►) simgesi bulunur) göreceksiniz.
2.  Bu yeşil butona tıklayın.
3.  Rider arka planda şu işlemleri yapacaktır:
    -   **Derleme (Compile):** Yazdığımız kodları bilgisayarın anlayacağı dile çevirir.
    -   **Web Sunucusunu Başlatma:** Uygulamanın bir web sitesi olarak çalışmasını sağlayan küçük bir sunucu (Kestrel) başlatır.
    -   **Tarayıcıyı Açma:** Varsayılan web tarayıcınızı (Chrome, Firefox vb.) açar ve uygulamanın adresini otomatik olarak yazar.

Tarayıcınızda "Outlook Mail Search" başlıklı web sayfası açıldığında her şey yolunda gitmiş demektir! Artık "Nasıl Kullanılır?" bölümündeki adımları takip ederek uygulamayı test edebilirsiniz.

## Nasıl Kullanılır?

Uygulama tarayıcıda açıldığında:

1.  **Dosya Seçin:** "Select Outlook Data File (.pst)" etiketli butona tıklayarak bilgisayarınızdan bir `.pst` dosyası seçin.
2.  **Arama Kriteri Girin (İsteğe Bağlı):**
    -   **From:** E-postaları gönderen kişiye göre filtrelemek için bu alanı doldurun.
    -   **Content:** E-posta konusu veya içeriğine göre arama yapmak için bu alanı doldurun.
3.  **Aramayı Başlatın:** "Search Emails" butonuna tıklayarak işlemi başlatın.
4.  **Sonuçları Görüntüleyin:** Arama tamamlandığında, eşleşen e-postalar sayfanın alt kısmında bir tablo halinde listelenecektir.

**Not:** Yüklenen `.pst` dosyasının boyutuna bağlı olarak arama işleminin süresi değişiklik gösterebilir. Lütfen büyük dosyalarda sabırla bekleyiniz. 