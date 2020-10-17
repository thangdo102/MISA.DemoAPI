using MISA.Common.Models;
using MISA.DataAccessLayer.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccessLayer.Repository
{

    /// <summary>
    /// Lớp Repository của Position
    /// Author: DVTHANG(17/10/2020)
    /// </summary>
    public class PositionRepository : BaseRepository<Position>, IPositionRepository
    {
        public PositionRepository(IDatabaseContext<Position> databaseContext) : base(databaseContext)
        {
        }
    }
}
