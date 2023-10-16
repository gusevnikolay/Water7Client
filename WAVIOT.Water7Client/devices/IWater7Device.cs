using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaviotAPI.API;

public interface IWater7Device
{
    void MessageHandler(RollResponse msg);
    void Show();
}

