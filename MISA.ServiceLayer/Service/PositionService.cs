using MISA.BusinessLayer.Interfaces;
using MISA.Common.Models;
using MISA.DataAccessLayer.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BusinessLayer.Service
{
    /// <summary>
    /// Lớp Service của Position
    /// Author: DVTHANG(16/10/2020)
    /// </summary>
    public class PositionService : BaseService<Position>, IPositionService
    {
        #region declare
        IPositionRepository _positionRepository;
        #endregion

        #region constructor
        public PositionService(IPositionRepository positionRepository) : base(positionRepository)
        {
            _positionRepository = positionRepository;
        }
        #endregion
    }
}
