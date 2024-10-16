# OOP Tamoyillari va Ularning Qo'llanilishi

Loyihada OOP tamoyillaridan foydalanganim quyidagicha:

## 1. Interfeyslar

Interfeyslar obyektlar o'rtasidagi aloqa va aloqalarni belgilaydi. Loyihada `IReservable` interfeysidan foydalanganman. Bu interfeys kitoblar va jurnallarni rezerv qilish uchun umumiy metodlarni belgilaydi.

public interface IReservable
{
    void Reserve();
    void CancelReservation();
}

public abstract class Publication
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsReserved { get; set; }

    public abstract void DisplayInfo(); // Abstrakt metod
}


public class Book : Publication, IReservable
{
    public int Pages { get; set; }

    public override void DisplayInfo()
    {
        System.Console.WriteLine($"Book Title: {Title}, Author: {Author}, Pages: {Pages}");
    }

    public void Reserve()
    {
        IsReserved = true;
        System.Console.WriteLine($"{Title} has been reserved.");
    }

    public void CancelReservation()
    {
        IsReserved = false;
        System.Console.WriteLine($"{Title} reservation has been cancelled.");
    }
}

public class Magazine : Publication, IReservable
{
    public int IssueNumber { get; set; }

    public override void DisplayInfo()
    {
        System.Console.WriteLine($"Magazine Title: {Title}, Author: {Author}, Issue: {IssueNumber}");
    }

    public void Reserve()
    {
        IsReserved = true;
        System.Console.WriteLine($"{Title} has been reserved.");
    }

    public void CancelReservation()
    {
        IsReserved = false;
        System.Console.WriteLine($"{Title} reservation has been cancelled.");
    }
}


public void DisplayInfo(string format)
{
    if (format == "detailed")
    {
        System.Console.WriteLine($"Title: {Title}, Author: {Author}, Pages: {Pages}, Reserved: {IsReserved}");
    }
    else
    {
        System.Console.WriteLine($"Book Title: {Title}");
    }
}


## Loyihada Duch Kelingan Qiyinchiliklar va Ularning Yechimlari

1. **Ma'lumotlarni boshqarish**: Loyihada kitoblar va jurnallarni qo'shish, yangilash va o'chirish jarayonlarida ma'lumotlarni samarali boshqarish qiyinchiliklar keltirib chiqardi.
   - **Yechim**: Bu masalani hal qilish uchun men OOP tamoyillaridan foydalangan holda interfeys va abstrakt klasslar orqali kodni modular va qayta ishlatiladigan holatga keltirdim. Har bir narsa uchun alohida klasslar yaratilib, bu ularning boshqarilishini osonlashtirdi.

2. **Rezervatsiya tizimi**: Kitob yoki jurnallarni rezervatsiya qilish vaqtida `isReserved` flagini boshqarish jarayonida ba'zi mantiqiy xatoliklar yuzaga keldi, masalan, foydalanuvchi bir kitobni ikki marta rezervatsiya qilishi mumkin edi.
   - **Yechim**: Bu muammoni hal qilish uchun rezervatsiya qilingan obyektni qayta rezervatsiya qilishga ruxsat bermaydigan qo'shimcha validatsiya qo'shildi.

3. **Qidiruv funksiyasi**: Kitob va jurnallarni qidirish vaqtida ma'lumotlarning katta hajmda bo'lishi tufayli qidiruv algoritmlarida samaradorlik masalalari paydo bo'ldi.
   - **Yechim**: Qidiruv jarayonini optimallashtirish uchun qidiruv natijalarini tezkor olishga yordam beradigan indekslash mexanizmlaridan foydalanildi.

4. **Foydalanuvchi interfeysi**: Konsol loyihasida foydalanuvchi bilan o'zaro aloqani qulay qilish qiyinchilik tug'dirdi.
   - **Yechim**: Foydalanuvchi tajribasini yaxshilash maqsadida, konsolda oddiy va tushunarli menyular va xabarlar orqali foydalanuvchi yo'naltirilishi amalga oshirildi.
