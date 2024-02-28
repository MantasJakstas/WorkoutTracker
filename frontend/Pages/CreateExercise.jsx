import React from "react";
import {
  Modal,
  Button,
  Typography,
  FormControl,
  MenuItem,
  InputLabel,
  Box,
  Stack,
  Container,
  Select,
  TextField,
} from "@mui/material";

export default function CreateExercise() {
  const [open, setOpen] = React.useState(false);
  const [group, setGroup] = React.useState("");

  const [name, setName] = React.useState("");
  const [nameError, setNameError] = React.useState(false);

  const handleClose = () => setOpen(false);
  const handleOpen = () => setOpen(true);

  const handleNameChange = (event) => {
    setName(event.target.value);
    if (event.target.validity.valid) {
      setNameError(false);
    } else {
      setNameError(true);
    }
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    const name = data.get("name");
    const group = data.get("group");
    console.log({
      name: name,
      group: group,
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
        Create Exercise
      </Button>
      <Modal open={open} onClose={handleClose}>
        <Container maxWidth={"sm"} component="main">
          <Box
            onSubmit={handleSubmit}
            component="form"
            mt={8}
            borderRadius={4}
            boxShadow={8}
            width="100%"
            height="42vh"
            backgroundColor="white"
            display="flex"
            flexDirection="column"
            autoComplete="off"
          >
            <Box mt={4} ml={5} width={"55%"}>
              <Typography variant="h5">Add new exercise:</Typography>
              <Stack spacing={4} mt={5}>
                <TextField
                  type="text"
                  onChange={handleNameChange}
                  required
                  value={name}
                  fullWidth
                  label="Exercise name"
                  name="name"
                  autoFocus
                  inputProps={{
                    pattern: "[A-Za-z ]+",
                  }}
                  error={nameError}
                  helperText={nameError ? "letters and spaces only" : " "}
                />
                <FormControl fullWidth>
                  <InputLabel>Muscle group</InputLabel>
                  <Select
                    name="group"
                    label="Muscle group"
                    value={group}
                    onChange={(value) => setGroup(value.target.value)}
                  >
                    <MenuItem value="Combined">Combined</MenuItem>
                    <MenuItem value="Shoulders">Shoulders</MenuItem>
                    <MenuItem value="Chest">Chest</MenuItem>
                    <MenuItem value="Arms">Arms</MenuItem>
                    <MenuItem value="Legs">Legs</MenuItem>
                    <MenuItem value="Abdominal">Abdominal</MenuItem>
                  </Select>
                </FormControl>
              </Stack>
            </Box>
            <Box
              display={"flex"}
              justifyContent={{ xs: "center", sm: "flex-end" }}
              ml={{ xs: 5, sm: 0 }}
              mt={8}
              mr={3}
              gap={3}
              mb={3}
            >
              <Button onClick={handleClose} variant="contained" color="error">
                Cancel
              </Button>
              <Button type="submit" variant="contained">
                Add exersice
              </Button>
            </Box>
          </Box>
        </Container>
      </Modal>
    </div>
  );
}
