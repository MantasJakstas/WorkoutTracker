import { useState } from "react";
import Heading from "./../components/Heading";
import Calendar from "../components/Calendar";

function App() {
  return (
    <div>
      <Heading headingTitle={"Workouts"}></Heading>
      <Calendar />
    </div>
  );
}

export default App;
