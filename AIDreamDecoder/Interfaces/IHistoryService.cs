using AIDreamDecoder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Interfaces
{
    public interface IHistoryService
    {
        /// <summary>
        /// Kullanıcının tüm geçmiş rüya analizlerini getirir.
        /// </summary>
        /// <param name="userId">Kullanıcının kimliği.</param>
        /// <returns>Kullanıcının rüya analiz geçmişi.</returns>
        Task<IEnumerable<AnalysisResult>> GetDreamAnalysisHistoryAsync(int userId);

        /// <summary>
        /// Belirli bir rüya için analiz geçmişini getirir.
        /// </summary>
        /// <param name="dreamId">Rüya kimliği.</param>
        /// <returns>Rüya analiz sonucu.</returns>
        Task<AnalysisResult> GetAnalysisResultByDreamIdAsync(int dreamId);

        /// <summary>
        /// Kullanıcının belirli bir tarih aralığındaki analizlerini getirir.
        /// </summary>
        /// <param name="userId">Kullanıcının kimliği.</param>
        /// <param name="startDate">Başlangıç tarihi.</param>
        /// <param name="endDate">Bitiş tarihi.</param>
        /// <returns>Tarih aralığındaki analizler.</returns>
        Task<IEnumerable<AnalysisResult>> GetDreamAnalysisHistoryByDateRangeAsync(int userId, DateTime startDate, DateTime endDate);

        //Kullanıcıların geçmiş rüya analizlerini listelemeyi ve tarih aralığı gibi özel filtreleme seçenekleri sunar.
        //GetDreamAnalysisHistoryByDateRangeAsync ile belirli bir zaman dilimine yönelik analizler alınabilir.
    }
}
