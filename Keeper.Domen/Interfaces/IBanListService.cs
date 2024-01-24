using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Interfaces;

// функции сервиса по работе с бан листом

public interface IBanListService
{

    // добавить пользователя в бан
    void AddToBanList(User user);

    // удалить пользователя из бана
    void DeleteFromBanList(User user);

}
