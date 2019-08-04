namespace Akili_Imza_Si.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class imzaSistemiDBContext : DbContext
    {
        public imzaSistemiDBContext()
            : base("name=imzaSistemiDBContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbIdariPersonel> tbIdariPersonels { get; set; }
        public virtual DbSet<tblAkedimisyen_Al_Dersler> tblAkedimisyen_Al_Dersler { get; set; }
        public virtual DbSet<tblAlinan_imza> tblAlinan_imza { get; set; }
        public virtual DbSet<tblBolumler> tblBolumlers { get; set; }
        public virtual DbSet<tblDersKaydı> tblDersKaydı { get; set; }
        public virtual DbSet<tblDersler> tblDerslers { get; set; }
        public virtual DbSet<tblDuyrular> tblDuyrulars { get; set; }
        public virtual DbSet<tblFakulteler> tblFakultelers { get; set; }
        public virtual DbSet<tblimzaliste> tblimzalistes { get; set; }
        public virtual DbSet<tblOgr_Duyrular> tblOgr_Duyrular { get; set; }
        public virtual DbSet<tblOgr_Ogrenci> tblOgr_Ogrenci { get; set; }
        public virtual DbSet<tblTarih> tblTarihs { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.TC)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Place_of_birth)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<tbIdariPersonel>()
                .Property(e => e.Kullanici_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<tbIdariPersonel>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tbIdariPersonel>()
                .Property(e => e.Ad)
                .IsUnicode(false);

            modelBuilder.Entity<tbIdariPersonel>()
                .Property(e => e.Soyad)
                .IsUnicode(false);

            modelBuilder.Entity<tbIdariPersonel>()
                .Property(e => e.Tc)
                .IsUnicode(false);

            modelBuilder.Entity<tbIdariPersonel>()
                .Property(e => e.D_Tarihi)
                .IsUnicode(false);

            modelBuilder.Entity<tbIdariPersonel>()
                .Property(e => e.Baba_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<tbIdariPersonel>()
                .Property(e => e.Anne_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<tbIdariPersonel>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<tbIdariPersonel>()
                .Property(e => e.E_posta)
                .IsUnicode(false);

            modelBuilder.Entity<tbIdariPersonel>()
                .Property(e => e.FakulteKod)
                .IsUnicode(false);

            modelBuilder.Entity<tbIdariPersonel>()
                .Property(e => e.Gorev)
                .IsUnicode(false);

            modelBuilder.Entity<tbIdariPersonel>()
                .Property(e => e.Fotograf)
                .IsUnicode(false);

            modelBuilder.Entity<tblAkedimisyen_Al_Dersler>()
                .Property(e => e.Ders_Kod)
                .IsUnicode(false);

            modelBuilder.Entity<tblAkedimisyen_Al_Dersler>()
                .Property(e => e.Derslik_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlinan_imza>()
                .Property(e => e.Tc)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlinan_imza>()
                .Property(e => e.Ad)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlinan_imza>()
                .Property(e => e.Soyad)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlinan_imza>()
                .Property(e => e.Ders_Kod)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlinan_imza>()
                .Property(e => e.Ders_Haftasi)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlinan_imza>()
                .Property(e => e.Ders_Tipi)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlinan_imza>()
                .Property(e => e.Ders_Saat)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlinan_imza>()
                .Property(e => e.imza_Tarihi)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlinan_imza>()
                .Property(e => e.imza_Saat)
                .IsUnicode(false);

            modelBuilder.Entity<tblBolumler>()
                .Property(e => e.Fakulte_Kodu)
                .IsUnicode(false);

            modelBuilder.Entity<tblBolumler>()
                .Property(e => e.Bolum_Kod)
                .IsUnicode(false);

            modelBuilder.Entity<tblBolumler>()
                .Property(e => e.Bolum_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<tblBolumler>()
                .Property(e => e.Bolum_Tip)
                .IsUnicode(false);

            modelBuilder.Entity<tblDersKaydı>()
                .Property(e => e.Ogr_No)
                .IsUnicode(false);

            modelBuilder.Entity<tblDersKaydı>()
                .Property(e => e.Ogr_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<tblDersKaydı>()
                .Property(e => e.Ogr_Soyad)
                .IsUnicode(false);

            modelBuilder.Entity<tblDersKaydı>()
                .Property(e => e.Drs_S_Z)
                .IsUnicode(false);

            modelBuilder.Entity<tblDersKaydı>()
                .Property(e => e.Ders_Kod)
                .IsUnicode(false);

            modelBuilder.Entity<tblDersKaydı>()
                .Property(e => e.Sinif)
                .IsUnicode(false);

            modelBuilder.Entity<tblDersler>()
                .Property(e => e.Bolum_Kod)
                .IsUnicode(false);

            modelBuilder.Entity<tblDersler>()
                .Property(e => e.Ders_Kod)
                .IsUnicode(false);

            modelBuilder.Entity<tblDersler>()
                .Property(e => e.Ders_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<tblDersler>()
                .Property(e => e.Teori_Saati)
                .IsUnicode(false);

            modelBuilder.Entity<tblDersler>()
                .Property(e => e.Piratik_Saati)
                .IsUnicode(false);

            modelBuilder.Entity<tblDersler>()
                .Property(e => e.Ekleme_Tarihi)
                .IsUnicode(false);

            modelBuilder.Entity<tblDuyrular>()
                .Property(e => e.PresonelID)
                .IsUnicode(false);

            modelBuilder.Entity<tblDuyrular>()
                .Property(e => e.BolumKod)
                .IsUnicode(false);

            modelBuilder.Entity<tblDuyrular>()
                .Property(e => e.FakulteKod)
                .IsUnicode(false);

            modelBuilder.Entity<tblDuyrular>()
                .Property(e => e.AkID)
                .IsUnicode(false);

            modelBuilder.Entity<tblDuyrular>()
                .Property(e => e.Baslik)
                .IsUnicode(false);

            modelBuilder.Entity<tblDuyrular>()
                .Property(e => e.Mesaj)
                .IsUnicode(false);

            modelBuilder.Entity<tblDuyrular>()
                .Property(e => e.Tarih)
                .IsUnicode(false);

            modelBuilder.Entity<tblDuyrular>()
                .Property(e => e.Gun)
                .IsUnicode(false);

            modelBuilder.Entity<tblDuyrular>()
                .Property(e => e.Ay)
                .IsUnicode(false);

            modelBuilder.Entity<tblFakulteler>()
                .Property(e => e.Fakulte_Kod)
                .IsUnicode(false);

            modelBuilder.Entity<tblFakulteler>()
                .Property(e => e.Fakulte_Adi)
                .IsUnicode(false);

            modelBuilder.Entity<tblimzaliste>()
                .Property(e => e.Ogr_No)
                .IsUnicode(false);

            modelBuilder.Entity<tblimzaliste>()
                .Property(e => e.Ogr_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<tblimzaliste>()
                .Property(e => e.Ogr_Soyad)
                .IsUnicode(false);

            modelBuilder.Entity<tblimzaliste>()
                .Property(e => e.Ders_Kod)
                .IsUnicode(false);

            modelBuilder.Entity<tblimzaliste>()
                .Property(e => e.Ders_Haftasi)
                .IsUnicode(false);

            modelBuilder.Entity<tblimzaliste>()
                .Property(e => e.Ders_Tipi)
                .IsUnicode(false);

            modelBuilder.Entity<tblimzaliste>()
                .Property(e => e.Derslik_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<tblimzaliste>()
                .Property(e => e.Ders_Saat)
                .IsUnicode(false);

            modelBuilder.Entity<tblimzaliste>()
                .Property(e => e.imza_Tarihi)
                .IsUnicode(false);

            modelBuilder.Entity<tblimzaliste>()
                .Property(e => e.imza_Saat)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Duyrular>()
                .Property(e => e.AkedimisyenID)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Duyrular>()
                .Property(e => e.DersKod)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Duyrular>()
                .Property(e => e.BolumKod)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Duyrular>()
                .Property(e => e.OgrNo)
                .IsFixedLength();

            modelBuilder.Entity<tblOgr_Duyrular>()
                .Property(e => e.Baslik)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Duyrular>()
                .Property(e => e.Mesaj)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Duyrular>()
                .Property(e => e.Saat)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Ogrenci>()
                .Property(e => e.Ogr_MacAddres)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Ogrenci>()
                .Property(e => e.Ogr_No)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Ogrenci>()
                .Property(e => e.Ogr_Password)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Ogrenci>()
                .Property(e => e.Ogr_Tc)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Ogrenci>()
                .Property(e => e.Ogr_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Ogrenci>()
                .Property(e => e.Ogr_SoyAd)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Ogrenci>()
                .Property(e => e.Ogr_Eposta)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Ogrenci>()
                .Property(e => e.Ogr_telefon)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Ogrenci>()
                .Property(e => e.Ogr_BabaAd)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Ogrenci>()
                .Property(e => e.Ogr_AnneAd)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Ogrenci>()
                .Property(e => e.Ogr_DogumYer)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Ogrenci>()
                .Property(e => e.Ogr_DogumTarihi)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Ogrenci>()
                .Property(e => e.Ogr_Fakulte)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Ogrenci>()
                .Property(e => e.Ogr_Program)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Ogrenci>()
                .Property(e => e.Ogr_Sinif)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Ogrenci>()
                .Property(e => e.Ogr_OgrenimSekli)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgr_Ogrenci>()
                .Property(e => e.Ogr_Fotograf)
                .IsUnicode(false);

            modelBuilder.Entity<tblTarih>()
                .Property(e => e.Yil)
                .IsUnicode(false);

            modelBuilder.Entity<tblTarih>()
                .Property(e => e.Ay)
                .IsUnicode(false);

            modelBuilder.Entity<tblTarih>()
                .Property(e => e.Gun)
                .IsUnicode(false);

            modelBuilder.Entity<tblTarih>()
                .Property(e => e.X)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Kullanici_Adi)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Ad)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Soyad)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Tc)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.D_Tarihi)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Baba_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Anne_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.E_posta)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.BolumKod)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.FakulteKod)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Unvani)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Fotograf)
                .IsUnicode(false);
        }
    }
}
