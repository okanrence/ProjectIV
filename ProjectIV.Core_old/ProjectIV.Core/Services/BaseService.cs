﻿using ProjectIV.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Services
{
    public abstract class BaseService {
        protected IUnitOfWork unitOfWork;

        public BaseService(IUnitOfWork unitOfWork = null) {
            if (unitOfWork == null) {
                this.unitOfWork = new UnitOfWork();
            }
            else
            {
                this.unitOfWork = unitOfWork;
            }
        }
 
        protected virtual void Dispose(bool disposing) {
            this.unitOfWork.Dispose();
        }
    }

}
