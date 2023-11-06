using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.BLL
{
    public class HomeManager : IHomeManager
    {
        private readonly IHomeRepository _repository;
        public HomeManager(IHomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddHomeVUrlText(HomeVUrl topText)
        {
            try
            {
                bool result = await _repository.AddHomeVUrlText(topText);

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {

                return await Task.FromResult(false);

            }
        }

        public List<HomeVUrl> GetHomeVUrl()
        {
            List<HomeVUrl> homeVUrl = new List<HomeVUrl>();

            homeVUrl = _repository.GetHomeVUrl();
            return homeVUrl;
        }
    }
}
