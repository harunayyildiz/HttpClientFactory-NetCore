# HttpClientFactory-NetCore
Http istekleri yapmamızı sağlan HttpClient(.net 4.5 ile geldi) sınıfının instance'ını oluşturmak için kullanılan sınıftır.
Dependency Injection kullanarak HttpClientFactory ile HttpClient elde etme yöntemidir.Sadece HttpClient kullanım durumunda her yeni bir instance uygulama için maliyet ve uygulamada kullanılacak socketlerin tüketilmesi demektir. HttpClientFactory ile HttpClient instance kontrolünü yapıp hem maliyet hemde socket yönünden tasarruf sağlıyor.


1.İşlem | 
------------ 
<img src="https://github.com/harunayyildiz/HttpClientFactory-NetCore/blob/master/httpclientFactory_OneProses.PNG" alt="Result" width="802" height="404">

2.İşlem | 
------------ 
<img src="https://github.com/harunayyildiz/HttpClientFactory-NetCore/blob/master/httpclientFactory_TwoProses.PNG" alt="Result" width="803" height="397">

3.İşlem | 
------------ 
<img src="https://github.com/harunayyildiz/HttpClientFactory-NetCore/blob/master/httpclientFactory_ThreeProses.PNG" alt="Result" width="572" height="445">
