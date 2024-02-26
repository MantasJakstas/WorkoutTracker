import React from "react";
import { Container } from "@mui/material";
import { LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { DateCalendar } from "@mui/x-date-pickers";
import dayjs from "dayjs";

export default function Calendar() {
  const [value, setValue] = React.useState(dayjs());
  const changedValue = (value) => {
    console.log(value.toJSON());
    setValue(value);
  };

  return (
    <div>
      <LocalizationProvider dateAdapter={AdapterDayjs}>
        <DateCalendar
          value={value}
          views={["day"]}
          onChange={(newValue) => changedValue(newValue)}
        />
      </LocalizationProvider>
    </div>
  );
}
