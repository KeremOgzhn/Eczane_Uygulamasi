# 🚀 Eczane_Uygulamasi

Bu proje, bir eczane yönetim sistemi için geliştirilmiş bir Windows Forms (C#) masaüstü uygulamasıdır. Uygulama, ilaç kayıtlarını yönetme, arama yapma ve ilaçlara ait görselleri görüntüleme gibi temel işlevleri sunar.

## 🎯 Projenin Amacı

Bu uygulama, eczane envanterindeki ilaçların dijital olarak takibini kolaylaştırmak amacıyla geliştirilmiştir. Kullanıcıların ilaç bilgilerini (kod, ad, fiyat, adet, fotoğraf) girmesine, güncellemesine, silmesine ve mevcut ilaçlar arasında arama yapmasına olanak tanır.

## ⚙️ Kurulum

1.  **Repoyu Klonlama:**
    *   Bu repoyu yerel makinenize klonlayın:
        ```bash
        git clone https://github.com/KeremOgzhn/Eczane_Uygulamasi.git
        ```
    *   Proje dizinine gidin:
        ```bash
        cd Eczane_Uygulamasi
        ```

2.  **Veritabanı Kurulumu:**
    *   Uygulama, yerel bir SQL Server örneği (`Server=.`) ve `eczanedb` adında bir veritabanı kullanır.
    *   `eczanedb` veritabanının ve içerisinde aşağıdaki gibi bir `ilac` tablosunun oluşturulduğundan emin olun:
        *   `siraNo` (INT, Primary Key, Auto Increment - Örnek, kodda `Cells[0]` olarak kullanılıyor)
        *   `ilacKodu` (VARCHAR/NVARCHAR - Örnek, `txtIlacKodu` ile eşleşiyor)
        *   `ilacAdi` (VARCHAR/NVARCHAR - Örnek, `txtIlacAdi` ile eşleşiyor)
        *   `fiyat` (DECIMAL/MONEY - Örnek, `txtFiyat` ile eşleşiyor)
        *   `adet` (INT - Örnek, `txtAdet` ile eşleşiyor)
        *   `fotograf` (VARCHAR/NVARCHAR - Fotoğraf dosyasının yolunu saklar, `txtFotografYolu` ile eşleşiyor)
    *   `veri tabanı dosyaları` klasöründe bulunan SQL script'lerini (eğer varsa) kullanarak veritabanını ve tabloyu oluşturabilirsiniz veya manuel olarak SQL Server Management Studio (SSMS) gibi bir araçla oluşturabilirsiniz.
    *   Bağlantı dizesi (`connectionString`) kod içerisinde `Server=.;Database=eczanedb;Integrated Security=True;` olarak tanımlanmıştır. Farklı bir SQL Server örneği veya ayarı kullanıyorsanız, `Form1.cs` dosyasındaki bu satırı güncellemeniz gerekebilir.

3.  **Projeyi Açma ve Çalıştırma:**
    *   `FormdaEczaneUygulaması` klasöründeki `FormdaEczaneUygulaması.sln` dosyasını Visual Studio ile açın.
    *   Projeyi Visual Studio üzerinden derleyin (Build) ve çalıştırın (Start F5).
  
## Veri Tabanı Dosyalarını Açma Rehberi

Bu projede kullanılan MSSQL veri tabanı dosyalarını (.mdf ve .ldf) kendi bilgisayarınızda açmak için aşağıdaki adımları izleyin:

### 1. Gereksinimler
- SQL Server (örn. SQL Server Express veya tam sürümü)
- SQL Server Management Studio (SSMS)

### 2. Veri Tabanını Eklemek (Attach)
1. .mdf ve .ldf dosyalarını bilgisayarınıza indirin.
2. SQL Server Management Studio’yu (SSMS) açın.
3. Sunucuya bağlanın.
4. “Databases” (Veritabanları) kısmına sağ tıklayın ve **Attach** (Ekle) seçeneğini seçin.
5. Açılan pencerede **Add** (Ekle) butonuyla .mdf dosyasını seçin.
6. SQL Server, .ldf dosyasını otomatik olarak bulacaktır. Bulamazsa, elle ekleyin.
7. **OK** diyerek işlemi tamamlayın.

### 3. Bağlantı Dizesini (Connection String) Güncelleyin
Projedeki bağlantı dizesini, kendi bilgisayarınızdaki veri tabanının yoluna göre güncelleyin:

```csharp
Data Source=.\SQLEXPRESS;AttachDbFilename=C:\KendiYolu\Veritabani.mdf;Integrated Security=True
```

> Not: `AttachDbFilename` kısmındaki yolu, kendi bilgisayarınızdaki .mdf dosyasının tam yoluna göre değiştirin.

### 4. Yetki Problemleri
Eğer dosya ile ilgili yetki sorunları yaşarsanız:
- Dosya üzerinde okuma/yazma izni olduğundan emin olun.
- SQL Server'ın çalıştığı kullanıcının bu dosyaya erişim izni olduğundan emin olun.

---

Herhangi bir sorun yaşarsanız veya adımlar hakkında sorunuz olursa lütfen bir issue açın!

## 🛠️ Kullanım

Uygulama başlatıldığında, ilaçların listelendiği bir ana form açılır. Form üzerinde ilaç bilgilerini girmek için metin kutuları, işlemler için butonlar ve ilaç fotoğrafını görüntülemek için bir resim kutusu bulunur.

**Temel İşlevler:**

1.  **İlaç Listeleme:**
    *   Uygulama açıldığında, `eczanedb` veritabanındaki `ilac` tablosunda bulunan tüm ilaç kayıtları otomatik olarak form üzerindeki tabloda (DataGridView) listelenir.

2.  **Yeni İlaç Ekleme:**
    *   **Bilgi Girişi:** `İlaç Kodu`, `İlaç Adı`, `Fiyat`, `Adet` metin kutularına yeni ilacın bilgilerini girin.
    *   **Fotoğraf Seçme:** `Fotoğraf Seç` butonuna tıklayarak ilaca ait bir görsel dosyası seçin. Seçilen fotoğrafın yolu `Fotoğraf Yolu` metin kutusunda görünecek ve fotoğraf yandaki resim kutusunda (PictureBox) görüntülenecektir.
    *   **Kaydetme:** `Ekle` butonuna tıklayarak yeni ilacı veritabanına kaydedin. Kayıt sonrası liste güncellenir ve giriş alanları temizlenir.

3.  **İlaç Bilgilerini Görüntüleme ve Seçme:**
    *   Tabloda (DataGridView) herhangi bir ilacın satırına tıklandığında, o ilaca ait bilgiler form üzerindeki ilgili metin kutularına (`İlaç Kodu`, `İlaç Adı`, `Fiyat`, `Adet`, `Fotoğraf Yolu`) otomatik olarak doldurulur.
    *   Seçilen ilacın fotoğrafı da resim kutusunda görüntülenir.

4.  **İlaç Güncelleme:**
    *   **İlaç Seçme:** Güncellemek istediğiniz ilacı tablodan seçin. Bilgileri otomatik olarak form alanlarına yüklenecektir.
    *   **Değişiklik Yapma:** Gerekli alanlardaki bilgileri (ilaç kodu, adı, fiyatı, adedi, fotoğraf yolu) güncelleyin. Fotoğrafı değiştirmek için `Fotoğraf Seç` butonunu kullanabilirsiniz.
    *   **Kaydetme:** `Güncelle` butonuna tıklayarak değişiklikleri veritabanına kaydedin. Liste güncellenir ve giriş alanları temizlenir.

5.  **İlaç Silme:**
    *   **İlaç Seçme:** Silmek istediğiniz ilacı tablodan seçin.
    *   **Silme:** `Sil` butonuna tıklayarak seçili ilacı veritabanından silin. İşlem sonrası liste güncellenir ve giriş alanları temizlenir.

6.  **İlaç Arama:**
    *   `Ara` metin kutusuna aramak istediğiniz ilacın adını veya kodunu yazın.
    *   `Ara` butonuna tıklayın. Arama kriterine uyan ilaçlar tabloda listelenecektir. Tüm listeyi tekrar görmek için arama kutusunu boşaltıp `Ara` butonuna tıklayabilir veya uygulamayı yeniden başlatabilirsiniz (mevcut kodda tüm listeyi geri getiren ayrı bir buton yok gibi görünüyor, `VerileriYukle` metodu tekrar çağrılabilir).

7.  **Giriş Alanlarını Temizleme:**
    *   `Temizle` butonuna tıklayarak form üzerindeki tüm giriş metin kutularını (`İlaç Kodu`, `İlaç Adı`, `Fiyat`, `Adet`, `Fotoğraf Yolu`) ve resim kutusunu temizleyebilirsiniz.

## 🤝 Katkıda Bulunma

Katkılarınızı bekliyoruz! Lütfen aşağıdaki adımları izleyin:

1.  Bu repoyu fork'layın.
2.  Yeni bir özellik dalı oluşturun: `git checkout -b yeni-ozellik`
3.  Değişikliklerinizi commit'leyin: `git commit -m 'Yeni bir özellik eklendi'`
4.  Dalınızı push'layın: `git push origin yeni-ozellik`
5.  Bir Pull Request açın.


---
