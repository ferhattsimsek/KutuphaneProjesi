using kutup.Data;
using Quartz;
using System;

public class KalanGunAzaltmaJob : IJob
{
    private readonly DataContext _context;
    public KalanGunAzaltmaJob(DataContext context)
    {
        _context = context;
    }
    private void AzaltKalanGunSayisi()
    {
        // Veritabanına bağlanmak için gerekli kodları ekleyin


        // Örneğin, Emanet sınıfındaki tüm öğeleri al ve kalan gün sayısını azalt
        var emanetler = _context.Emanetler.Where(x => x.getirdimi == false).ToList();
        foreach (var emanet in emanetler)
        {
            emanet.KalanGünSayısı--;
            _context.Update(emanet);


            // Değişiklikleri kaydet
            _context.SaveChanges();
        }
    }

    public Task Execute(IJobExecutionContext context)
    {
        var emanetler = _context.Emanetler.Where(x => x.getirdimi == false).ToList();
        foreach (var emanet in emanetler)
        {
            emanet.KalanGünSayısı--;
            _context.Update(emanet);


            // Değişiklikleri kaydet
            _context.SaveChanges();
        }
        return Task.CompletedTask;

    }
}
