using Invocators.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invocators.Models
{
    internal interface IInvocation
    {
        void MakeAttack(BaseInvocation target);
        void TakeDamage(int damage);
    }
}
