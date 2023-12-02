# Studiofy.BlazorScheduler

[![Nuget](https://img.shields.io/nuget/v/Studiofy.BlazorScheduler?label=NuGet%20Package)](https://www.nuget.org/packages/Studiofy.BlazorScheduler/) [![Nuget](https://img.shields.io/nuget/dt/Studiofy.BlazorScheduler?label=Downloads)](https://www.nuget.org/packages/Studiofy.BlazorScheduler/) [![GitHub](https://img.shields.io/github/issues/Studiofy/BlazorScheduler?label=Open%20Issues
)](https://github.com/Studiofy/BlazorScheduler/issues)

## Overview
Studiofy.BlazorScheduler is a component library that can handle multiple appointments in multiple months or years to come.

## Usage
1. Run `Install-Package Studiofy.BlazorScheduler` in the package manager console to install the latest package in your frontend project.
2. Add references to necessary js & css files in your `index.html`
    - Add `<link href="_content/Studiofy.BlazorScheduler/css/styles.css" rel="stylesheet" />` to the head
    - Add `<script src="_content/Studiofy.BlazorScheduler/js/scripts.js"></script>` to the body
3. Add `@using Studiofy.BlazorScheduler` to your _Import.razor page
4. Create a local list of Appointments using `List<TItem>`, or use a database like MSSQL to create a table for Appointments.
  ```C#
  AppointmentModel.cs
  public class AppointmentModel
  {
      public DateTime Start { get; set; }

      public DateTime End { get; set; }

      public string AppointmentLabel { get; set; }
  }
  
  Appointments.razor
  private List<AppointmentModel> Appointments = [];
  ```
5. Use the `Scheduler` component on your desired page. (e.g. Appointments.razor)
  ```C#
  <Scheduler CurrentDate="DateTime.Now">
      <Appointments>
          @foreach (var Appointment in Appointments)
          {
              <Appointment Start="@Appointment.Start"
                           End="@Appointment.End">
                  @AppointmentLabel
              </Appointment>
          }
      </Appointments>
  </Scheduler>
  ```

## Interactions
There are 3 callbacks that the scheduler provides.
- `Task OnAddingNewAppointment(DateTime start, DateTime end)` - invoked when the user is done dragging to create a new appointment, the range is returned in the parameters
- `Task OnOverflowAppointmentClick(DateTime day)` - invoked when the user clicks on an "overflowing" appointment, the date of the overflow is returned in the parameters
- `Task OnRequestNewData(DateTime start, DateTime end)` - invoked on first render and when the month is changed, the range is returned in the parameters
