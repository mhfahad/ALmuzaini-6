using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.DAL.DAL;
using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.BLL
{
    public class KoiskManager : IKoiskManager
    {
        private readonly IKoiskRepository _koiskRepository;
        public KoiskManager(IKoiskRepository koiskRepository)
        {
            _koiskRepository = koiskRepository;
        }

        public async Task<bool> AddKoiskDetail(KoiskDetail koiskDetail)
        {
            try
            {
                bool result = await _koiskRepository.AddKoiskDetail(koiskDetail);

                return await Task.FromResult(result);
            }
            catch (Exception)
            {

                return await Task.FromResult(false);

            }
        }

        public List<KoiskDetail> GetKoiskDetail()
        {
            List<KoiskDetail> koiskDetail = new List<KoiskDetail>();

            koiskDetail = _koiskRepository.GetKoiskDetail();
            return koiskDetail;
        }

        public KoiskBanner GetKoiskTopBanner()
        {

            KoiskBanner koiskBanner = new KoiskBanner();

            koiskBanner = _koiskRepository.GetKoiskTopBanner();
            return koiskBanner;
        }

        public async Task<bool> UpdateKoiskBannerImagePath(KoiskBanner koiskBanner)
        {
            try
            {
                bool result = await _koiskRepository.UpdateKoiskBannerImagePath(koiskBanner);
                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
