import React from "react";
import Heading from "./../components/Heading";
import { Box, Button, Container, Typography } from "@mui/material";
import { Link } from "react-router-dom";

export default function CreateWorkout() {
  return (
    <div>
      <Heading headingTitle={"Create Workout"} />
      <Container>
        <Box display={"flex"} justifyContent={"space-between"} mt={5}>
          <Box>
            <Typography>Create Your Workout:</Typography>
            <Link to="/">
              <Button
                sx={{ height: 50, borderRadius: 3, mt: 2, width: 350 }}
                variant="contained"
                color="success"
              >
                Create Workout
              </Button>
            </Link>
          </Box>
          <Box>
            <Typography>Dont Have an exercise?</Typography>
            <Link to="/exercise">
              <Button
                sx={{ height: 50, borderRadius: 3, mt: 2, width: 350 }}
                variant="contained"
                color="success"
              >
                Create Exercise
              </Button>
            </Link>
          </Box>
        </Box>
      </Container>
    </div>
  );
}
