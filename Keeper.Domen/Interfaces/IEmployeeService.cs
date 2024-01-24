using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Interfaces;

// описание функциональности сотрудников

public interface IEmployeeService
{

    // аутентификация сотрудника по коду ??? это функция сотрудника?
    Employee Auth(string code);

    // разрешение на проход 
    bool Open();

    // поиск по QR 
    Statement SearchStatementByQr();

    // проверка, что сотрудник охраны разрешил доступ

    // подтверждение сотрудником подразделения время прихода 

    // проверка превышения времени перемещения от проходной до подразделения

    // отправка оповщения о нарушении сотруднику охраны и сотруднику подразделения

    // проверка времени окончания посещения

    // подтверждение времени завершения посещения

    // отчеты о посещении

    // бибилиотека классов
}
