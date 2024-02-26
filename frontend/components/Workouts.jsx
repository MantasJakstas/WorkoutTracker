import React from "react";
import { Button } from "@mui/material";
import { Link } from "react-router-dom";
export default function Workouts() {
  return (
    <div>
      <Link to="/workout">
        <Button
          sx={{ height: 50, borderRadius: 3, mt: 2, width: 350 }}
          variant="contained"
          color="success"
        >
          New Workout
        </Button>
      </Link>
    </div>
  );
}
