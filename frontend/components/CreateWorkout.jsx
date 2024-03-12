import React from "react";
import {
  Box,
  Button,
  Modal,
  Typography,
  Grid,
  Container,
  Paper,
  TextField,
  FormControlLabel,
  Autocomplete,
} from "@mui/material";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import AddExerciseFormInput from "./AddExerciseFormInput";
import axios from "axios";
export default function CreateWorkout({ exercises }) {
  const exerciseName = [];
  exercises.map((exercise) => {
    exerciseName.push(exercise.name);
  });

  const [open, setOpen] = React.useState(false);
  const [render, setRender] = React.useState(["Sample"]);
  const handleClose = () => {
    setOpen(false);
    setRender(["Sample"]);
  };
  const handleOpen = () => setOpen(true);

  const AddComponent = () => {
    setRender([...render, "Sample"]);
  };

  const RemoveComponent = () => {
    if (render.length == 1) {
      return;
    }
    render.pop();
    setRender([...render]);
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    const exercsisesArray = [];

    const workouteName = data.get("workoutName");
    const exercisesName = data.getAll("exercise");
    const repetitions = data.getAll("repetitions");
    const weight = data.getAll("repetitions");
    const bodyWeight = data.get("bodyWeight");
    const workoutDate = data.get("date");
    for (let i = 0; i < exercisesName.length; i++) {
      exercsisesArray.push({
        exerciseName: exercisesName[i],
        repetition: repetitions[i],
        weight: weight[i],
      });
    }

    axios
      .post("https://localhost:7020/api/Workout/createWithExercises", {
        workoutName: workouteName,
        bodyWeight: bodyWeight,
        workoutDate: workoutDate,
        exercisesWithReps: exercsisesArray,
      })
      .then((response) => {
        console.log(response);
        //shouldRefetch();
      })
      .catch((error) => {
        console.log(error);
      });
    handleClose();
  };

  return (
    <div>
      <Button
        sx={{ height: 50, borderRadius: 3, mt: 2, width: 350 }}
        variant="contained"
        color="success"
        onClick={handleOpen}
      >
        Create Workout
      </Button>
      <Modal open={open} onClose={handleClose}>
        <Container component="main" maxWidth="lg">
          <Paper
            variant="outlined"
            sx={{ my: { xs: 3, md: 8 }, p: { xs: 2, md: 3 } }}
          >
            <Typography sx={{ my: 3 }} component="h1" variant="h5">
              Create workout
            </Typography>
            <Box component="form" onSubmit={handleSubmit}>
              <Grid container spacing={3}>
                <Grid item xs={12}>
                  <TextField
                    required
                    name="workoutName"
                    label="Workout Name"
                    fullWidth
                    variant="outlined"
                  />
                </Grid>

                <Grid item xs={10} sm={8}>
                  {render.map((exercsises, i) => (
                    <AddExerciseFormInput key={i} exerciseName={exerciseName} />
                  ))}
                </Grid>

                <Grid item xs={2} mt={1}>
                  <Button onClick={AddComponent} variant="contained">
                    +
                  </Button>
                  <Button
                    sx={{ marginLeft: 2 }}
                    onClick={RemoveComponent}
                    variant="contained"
                    color="error"
                  >
                    -
                  </Button>
                </Grid>
                <Grid item xs={12}>
                  <TextField
                    required
                    inputProps={{
                      pattern: "[0-9]+",
                    }}
                    name="bodyWeight"
                    label="BodyWeight"
                    fullWidth
                    variant="outlined"
                  />
                </Grid>
                <Grid item xs={12}>
                  <LocalizationProvider dateAdapter={AdapterDayjs}>
                    <DatePicker
                      required
                      name="date"
                      label="Date"
                      fullWidth
                      variant="standard"
                    />
                  </LocalizationProvider>
                </Grid>
                <Grid item xs={1.3}>
                  <Button
                    onClick={handleClose}
                    variant="contained"
                    color="error"
                  >
                    Cancel
                  </Button>
                </Grid>
                <Grid item xs={6}>
                  <Button type="submit" variant="contained">
                    Add Workout
                  </Button>
                </Grid>
              </Grid>
            </Box>
          </Paper>
        </Container>
      </Modal>
    </div>
  );
}
