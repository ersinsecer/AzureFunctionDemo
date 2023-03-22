# AzureFunctionDemo

- Function http://localhost:7119/api/validateEmail endpointi üzerinden POST isteği atarak çalıştırılmaktadır. 
- Function öncelikle querystring üzerinden gelen email değerine bakıyor (http://localhost:7119/api/validateEmail?email=deneme@deneme.com). Querystringden değer gelmiyorsa body kısmından json formatında gelen { """: "emailaddress" } değerine bakıyor.
- Bir değer gelirse mail validasyonunu yapıp geriye string bir sonuç dönmektedir. Değer alınamazsa invalid dönmektedir.
- Function http üzerinden tetiklenebilmesi için Trigger type olarak HttpTrigger kullanıldı. Locale olduğundan yetklilendirme bulunmuyor.
