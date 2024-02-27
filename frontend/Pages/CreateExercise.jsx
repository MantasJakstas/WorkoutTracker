import React from "react";
import {
  Modal,
  Button,
  Typography,
  FormControl,
  Input,
  InputLabel,
  Box,
  Stack,
  Container,
  useMediaQuery,
  Fade,
  TextField,
} from "@mui/material";

export default function CreateExercise() {
  const [open, setOpen] = React.useState(false);
  const handleClose = () => setOpen(false);
  const handleOpen = () => setOpen(true);
  const isSmallerThan600 = useMediaQuery("(max-width:600px)");
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
            mt={8}
            borderRadius={8}
            boxShadow={8}
            width="100%"
            height="40vh"
            backgroundColor="white"
            display="flex"
            flexDirection="column"
          >
            <Box mt={4} ml={5} width={"50%"}>
              <Typography variant="h5">Add new excercise:</Typography>
              <Stack spacing={3} mt={3}>
                <TextField required fullWidth label="Excercise name" />
                <FormControl variant="standard">
                  <InputLabel>Muslce Group</InputLabel>
                  <Input required />
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
              <Button variant="contained">Add excersice</Button>
            </Box>
          </Box>
        </Container>
      </Modal>
    </div>
  );
}
