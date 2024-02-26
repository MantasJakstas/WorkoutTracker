import { useState } from "react";
import Heading from "./../components/Heading";
import Calendar from "../components/Calendar";
import { Box } from "@mui/material";
import { Link, Route, Routes } from "react-router-dom";
import CreateWorkout from "../Pages/CreateWorkout";
import CreateExcercise from "../Pages/CreateExercise";

function App() {
  return (
    <div>
      <Routes>
        <Route path="/" element={<Calendar />}></Route>
        <Route path="/workout" element={<CreateWorkout />}></Route>
        <Route path="/exercise" element={<CreateExcercise />}></Route>
      </Routes>
    </div>
  );
}

export default App;
