using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Mappers
{
    public interface ITimesheetEntryMapper
    {
        public TimesheetEntry MapViewModelToTimesheetEntry(TimesheetEntryViewModel viewModel);
    }
}
