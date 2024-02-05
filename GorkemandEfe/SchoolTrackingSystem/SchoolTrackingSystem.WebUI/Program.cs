//Yaptığımız bu programda aktif öğrenci listesi tutabiliyor, Aktif/Pasif öğrenci bilgilerine ulaşabiliyoruz. Yaptığımız BU programa veri silme özelliği eklemedik çünkü Aktif/Pasif özelliği ile geçmiş öğrenci verilerine de ulaşmamızı daha doğru bulduk. Görkem Özer & Eyüp Efe kaya
//Katmanları Görkem Özer oluşturdu Eyüp Efe Kaya Yorum satırlarını ekledi.
var builder = WebApplication.CreateBuilder(args);

//container'a servisler ekliyoruz.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddRazorPages();

var app = builder.Build();

// HTTP istek hattını yapılandırma
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(name: "admin", pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");
app.MapControllerRoute(name: "default", pattern: "{controller=anasayfa}/{action=index}/{id?}");

app.Run();
