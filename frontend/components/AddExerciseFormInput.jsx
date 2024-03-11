import React from "react";
import { Grid, TextField, Autocomplete, Button } from "@mui/material";

function AddExerciseFormInput({ exercises }) {
  return (
    <Grid container spacing={3} mb={1}>
      <Grid item xs={4} sm={4}>
        <Autocomplete
          options={!exercises ? [{ label: "Loading..." }] : exercises}
          renderInput={(params) => (
            <TextField required {...params} name="exercise" label="Exercise" />
          )}
        />
      </Grid>
      <Grid item xs={4} sm={4}>
        <TextField
          required
          name="repetitions"
          label="Repetitions"
          fullWidth
          variant="outlined"
        />
      </Grid>
      <Grid item xs={4} sm={4}>
        <TextField name="weight" label="Weight" fullWidth variant="outlined" />
      </Grid>
    </Grid>
  );
}

export default AddExerciseFormInput;
