import React, { useEffect } from "react";
import Heading from "../components/Heading";
import { Box, Button, Container, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import CreateExercise from "../components/CreateExercise";
import ExercisesTable from "../components/ExercisesTable";
import axios, { isCancel, AxiosError } from "axios";
import CreateWorkout from "../components/CreateWorkout";

const getExercises = async () => {
  try {
    const response = await axios.get("https://localhost:7020/api/Exercise");
    return response.data;
  } catch (error) {
    console.log(error);
  }
};

export default function WorkoutPage() {
  const [exercises, setData] = React.useState([]);
  const [shouldRefetch, setShouldRefetch] = React.useState(false);

  useEffect(() => {
    const fetchData = async () => {
      const exercisesData = await getExercises();
      setData(exercisesData);
    };
    fetchData();
  }, [shouldRefetch]);

  const handleRefresh = () => {
    setShouldRefetch(!shouldRefetch);
  };

  return (
    <div>
      <Heading headingTitle="Create Workout" />
      <Container component="main">
        <Box
          display={"flex"}
          flexDirection={{ xs: "column", sm: "row" }}
          justifyContent="space-between"
          mt={5}
        >
          <Box>
            <Typography>Create Your Workout:</Typography>
            <CreateWorkout exercises={exercises} />
          </Box>
          <Box>
            <Typography>Dont Have an exercise?</Typography>
            <CreateExercise shouldRefetch={handleRefresh} />
            <ExercisesTable
              exercises={exercises}
              shouldRefetch={handleRefresh}
            />
          </Box>
        </Box>
      </Container>
    </div>
  );
}
