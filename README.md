Program, belirtilen databaseden alınan bilgilerle öncelikle giriş yapıyor, daha sonrasında ise kullanıcı ekleme, listeleme, silme ve güncelleme işlemlerini yapıyor.

Yazılan Sql'de
 -KullaniciID,
 -KullaniciAd,
 -KullaniciSifre 
sütunları bulunmaktadır.

programda belirtilen işlemleri yapmak için kullanılan stored procedure'ler ise,
 create proc sp_KullaniciGoruntule
as
	select * from Kullanici
go

create proc sp_KullaniciEkle
@KullaniciAd nvarchar(50),
@KullaniciSifre nvarchar(50)
as
insert into Kullanici values (@KullaniciAd, @KullaniciSifre)
go

create proc sp_KullaniciSil
@KullaniciID integer
as
	delete Kullanici where KullaniciID = @KullaniciID
go

create proc sp_KullaniciDuzenle
@KullaniciID integer,
@KullaniciAd nvarchar(50),
@KullaniciSifre nvarchar(50)
as
	update Kullanici
	set KullaniciAd=@KullaniciAd,
	KullaniciSifre=@KullaniciSifre
	where KullaniciID =@KullaniciID
go

create proc sp_KullaniciDenetim
@KullaniciAd nvarchar(50),
@KullaniciSifre nvarchar(50)
as
	Select * from Kullanici
	where KullaniciAd = @KullaniciAd
	and KullaniciSifre = @KullaniciSifre
	go
