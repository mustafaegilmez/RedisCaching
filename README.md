.NET Core Caching Örneği (Redis & In-Memory)
📌 Projenin Amacı
Bu proje, .NET Core ortamında önbellekleme (caching) yöntemlerini basit örneklerle göstermeyi amaçlar. Hem In-Memory Caching hem de Redis tabanlı Distributed Caching uygulanmıştır.
🧱 Yapı
- InMemoryCaching: Bellek içi önbellekleme (IMemoryCache kullanır)
- DistributedCaching: Redis tabanlı önbellekleme (IDistributedCache kullanır)
⚙️ Kullanılan Teknolojiler
- ASP.NET Core Web API
- IMemoryCache
- IDistributedCache
- Redis (Docker ile çalıştırıldı)
🚀 Kullanım
- Her iki proje ayrı ayrı çalıştırılabilir.
- Redis için Docker ile Redis başlatıldı:
  docker run --name redis-demo -p 6379:6379 -d redis
📌 Örnekler
- /api/values/set: İlgili değerleri cache’e kaydeder
- /api/values/get: Cache’ten verileri getirir
- /api/values/setDate & getDate: Zaman damgası ile cacheleme (In-Memory)
👤 Geliştirici
Mustafa Eğilmez
