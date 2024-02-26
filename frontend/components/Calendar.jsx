import React from "react";
import { Box, Container, Button } from "@mui/material";
import { LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { DateCalendar } from "@mui/x-date-pickers";
import dayjs from "dayjs";
import Workouts from "./Workouts";
import Heading from "./Heading";

export default function Calendar() {
  const [date, setDate] = React.useState(dayjs());
  const changedValue = (value) => {
    console.log(value.toJSON());
    setDate(value);
  };

  return (
    <div>
      <Heading headingTitle={"Workouts"}></Heading>
      <Box display={"flex"} flexDirection={"row"} justifyContent={"center"}>
        <LocalizationProvider dateAdapter={AdapterDayjs}>
          <DateCalendar
            sx={{ margin: 0, mr: 5 }}
            value={date}
            views={["day"]}
            onChange={(newValue) => changedValue(newValue)}
          />
          <Workouts />
        </LocalizationProvider>
      </Box>
    </div>
  );
}
