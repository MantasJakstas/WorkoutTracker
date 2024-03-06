import { useState } from "react";
import Heading from "./../components/Heading";
import Calendar from "../components/Calendar";
import { Box } from "@mui/material";
import { Link, Route, Routes } from "react-router-dom";
import WorkoutPage from "../Pages/WorkoutPage";

function App() {
  return (
    <div>
      <Routes>
        <Route path="/" element={<Calendar />}></Route>
        <Route path="/workout" element={<WorkoutPage />}></Route>
        <Route path="/exercise" element={<WorkoutPage />}></Route>
      </Routes>
    </div>
  );
}

export default App;
