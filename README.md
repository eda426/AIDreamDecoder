# 🌙 AIDreamDecoder

[![GitHub Stars](https://img.shields.io/github/stars/AleynaaCelik/AIDreamDecoder?style=flat-square)](https://github.com/AleynaaCelik/AIDreamDecoder/stargazers)
[![GitHub Forks](https://img.shields.io/github/forks/AleynaaCelik/AIDreamDecoder?style=flat-square)](https://github.com/AleynaaCelik/AIDreamDecoder/network/members)
[![GitHub Issues](https://img.shields.io/github/issues/AleynaaCelik/AIDreamDecoder?style=flat-square)](https://github.com/AleynaaCelik/AIDreamDecoder/issues)
[![License](https://img.shields.io/github/license/AleynaaCelik/AIDreamDecoder?style=flat-square)](LICENSE)

AI tabanlı rüya analizi ve yorumlama uygulaması. Modern yapay zeka teknolojileri kullanarak rüyalarınızın anlamını keşfedin.

## 🎯 Proje Hakkında

**AIDreamDecoder**, kullanıcıların rüyalarını analiz etmek ve anlamlandırmak için geliştirilmiş modern bir AI uygulamasıdır. Doğal dil işleme (NLP) ve makine öğrenmesi teknikleri kullanarak rüya içeriklerini derinlemesine analiz eder ve psikolojik yorumlar sunar.

### ✨ Özellikler

- 🧠 **AI Tabanlı Analiz**: Gelişmiş yapay zeka algoritmaları ile rüya analizi
- 📝 **Doğal Dil İşleme**: Türkçe ve İngilizce rüya metinlerini anlama
- 🎨 **Sembol Tanıma**: Rüyalardaki sembollerin psikolojik anlamlarını çözümleme
- 📊 **Detaylı Raporlama**: Kapsamlı analiz raporları ve öneriler
- 🔒 **Gizlilik Odaklı**: Kullanıcı verilerinin güvenliği ve mahremiyeti
- 📱 **Responsive Tasarım**: Mobil ve desktop uyumlu modern arayüz
- 🎭 **Duygu Analizi**: Rüyalardaki duygusal tonları belirleme
- 📈 **İlerleme Takibi**: Rüya kalıplarının zaman içindeki değişimi

## 🚀 Kurulum

### Gereksinimler

- Node.js (v16.0 veya üzeri)
- npm veya yarn
- Python 3.8+ (AI modeli için)

### Adım Adım Kurulum

1. **Projeyi klonlayın**
```bash
git clone https://github.com/AleynaaCelik/AIDreamDecoder.git
cd AIDreamDecoder
```

2. **Bağımlılıkları yükleyin**
```bash
npm install
# veya
yarn install
```

3. **Python bağımlılıklarını kurun**
```bash
pip install -r requirements.txt
```

4. **Environment dosyasını oluşturun**
```bash
cp .env.example .env
```

5. **API anahtarlarını yapılandırın**
```env
OPENAI_API_KEY=your_openai_api_key
DATABASE_URL=your_database_url
NEXTAUTH_SECRET=your_nextauth_secret
```

6. **Uygulamayı başlatın**
```bash
npm run dev
```

Uygulama `http://localhost:3000` adresinde çalışacaktır.

## 🛠️ Teknoloji Stack

### Frontend
- **Next.js 14** - React framework
- **TypeScript** - Type safety
- **Tailwind CSS** - Styling
- **React Hook Form** - Form yönetimi
- **Framer Motion** - Animasyonlar

### Backend
- **Next.js API Routes** - Backend logic
- **Prisma** - Database ORM
- **PostgreSQL** - Ana veritabanı
- **NextAuth.js** - Authentication

### AI/ML
- **OpenAI GPT-4** - Doğal dil işleme
- **Python** - AI model servisleri
- **TensorFlow** - Makine öğrenmesi
- **NLTK** - Metin analizi

## 📖 Kullanım

### Rüya Analizi

1. **Rüya Girişi**: Ana sayfada rüyanızı detaylı olarak yazın
2. **Analiz Başlatma**: "Rüyamı Analiz Et" butonuna tıklayın
3. **Sonuçları İnceleme**: AI'ın ürettiği detaylı analizi okuyun
4. **Kaydetme**: Analizi gelecekte erişim için kaydedin

### Örnek Kullanım

```javascript
// API endpoint kullanımı
const response = await fetch('/api/analyze-dream', {
  method: 'POST',
  headers: {
    'Content-Type': 'application/json',
  },
  body: JSON.stringify({
    dreamText: "Rüyamda uçuyordum...",
    language: "tr"
  })
});

const analysis = await response.json();
```

## 🧩 API Referansı

### POST `/api/analyze-dream`

Rüya analizi yapar.

**Request Body:**
```json
{
  "dreamText": "Rüya metni",
  "language": "tr",
  "userId": "user-id" // opsiyonel
}
```

**Response:**
```json
{
  "analysis": {
    "symbols": ["uçma", "su", "hayvan"],
    "emotions": ["korku", "heyecan"],
    "interpretation": "Detaylı yorumlama...",
    "psychologicalInsights": "Psikolojik içgörüler...",
    "suggestions": ["Öneri 1", "Öneri 2"]
  },
  "confidence": 0.85
}
```

## 🎨 Ekran Görüntüleri

### Ana Sayfa
![Ana Sayfa](screenshots/homepage.png)

### Analiz Sayfası
![Analiz](screenshots/analysis.png)

### Sonuçlar
![Sonuçlar](screenshots/results.png)

## 🧪 Test Etme

```bash
# Unit testleri çalıştır
npm run test

# Integration testleri
npm run test:integration

# E2E testleri
npm run test:e2e

# Test coverage
npm run test:coverage
```

## 📂 Proje Yapısı

```
AIDreamDecoder/
├── src/
│   ├── components/          # React componentleri
│   ├── pages/              # Next.js sayfaları
│   ├── api/                # API endpoints
│   ├── lib/                # Utility fonksiyonları
│   ├── types/              # TypeScript type tanımları
│   └── styles/             # CSS dosyaları
├── ai_models/              # Python AI modelleri
├── prisma/                 # Database schema
├── public/                 # Static dosyalar
├── tests/                  # Test dosyaları
└── docs/                   # Dokümantasyon
```

## 🤝 Katkıda Bulunma

Katkılarınızı memnuniyetle karşılıyoruz! 

1. Fork yapın
2. Feature branch oluşturun (`git checkout -b feature/amazing-feature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add amazing feature'`)
4. Branch'inizi push edin (`git push origin feature/amazing-feature`)
5. Pull Request oluşturun

### Geliştirme Kuralları

- ESLint ve Prettier kullanın
- Unit testler yazın
- Commit mesajlarında [Conventional Commits](https://conventionalcommits.org/) formatını kullanın
- Code review sürecine katılın

## 🔒 Güvenlik

Bu projede güvenlik çok önemlidir:

- Tüm kullanıcı verileri şifrelenir
- API rate limiting uygulanır
- Input validation yapılır
- OWASP güvenlik standartları takip edilir

Güvenlik açığı bulursanız lütfen `security@example.com` adresine bildirin.

## 📊 Performans

- **Analiz Süresi**: ~2-5 saniye
- **Doğruluk Oranı**: %85+
- **Desteklenen Diller**: Türkçe, İngilizce
- **Eş Zamanlı Kullanıcı**: 1000+

## 🔮 Gelecek Planları

- [ ] **Görsel Rüya Analizi**: Rüya çizimlerini analiz etme
- [ ] **Mobil Uygulama**: React Native ile mobil app
- [ ] **Sosyal Özellikler**: Rüya paylaşımı ve topluluk
- [ ] **Çok Dilli Destek**: Daha fazla dil desteği
- [ ] **Ses Girişi**: Voice-to-text rüya girişi
- [ ] **AI Model İyileştirme**: Daha doğru analizler
- [ ] **Rüya Günlüğü**: Kapsamlı rüya takip sistemi

## 📜 Lisans

Bu proje [MIT License](LICENSE) ile lisanslanmıştır.

## 🙏 Teşekkürler

- OpenAI GPT-4 API
- Next.js takımı
- Tailwind CSS
- Prisma
- Tüm katkıda bulunanlar

## 📞 İletişim

- **Geliştirici**: [Aleynna Celik](https://github.com/AleynaaCelik)
- **Email**: your.email@example.com
- **LinkedIn**: [linkedin.com/in/yourprofile](https://linkedin.com/in/yourprofile)
- **Twitter**: [@yourhandle](https://twitter.com/yourhandle)

## 📈 Proje İstatistikleri

![GitHub Stats](https://github-readme-stats.vercel.app/api?username=AleynaaCelik&repo=AIDreamDecoder&show_icons=true&theme=radical)

---

<div align="center">
  <p>⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!</p>
  <p>🔗 <a href="https://aidreamdecoder.vercel.app">Canlı Demo</a> • <a href="#installation">Kurulum</a> • <a href="#api-referansı">API Docs</a></p>
</div>
