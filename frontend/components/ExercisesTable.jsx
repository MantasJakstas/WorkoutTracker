import React, { useEffect } from "react";
import {
  Table,
  TableContainer,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  Button,
  Typography,
} from "@mui/material";
import axios from "axios";
import DeleteIcon from "@mui/icons-material/Delete";

export default function ExercisesTable({ exercises, shouldRefetch }) {
  const onDelete = async (id) => {
    try {
      const response = await axios.delete(
        `https://localhost:7020/api/Exercise/${id}`
      );
      console.log(response);
      shouldRefetch();
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <div>
      <TableContainer>
        <Table sx={{ minWidth: 350, marginTop: 2 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>
                <Typography>Name</Typography>
              </TableCell>
              <TableCell align="right">
                <Typography>Muscle Group</Typography>
              </TableCell>
              <TableCell align="center">
                <Typography>Delete</Typography>
              </TableCell>
            </TableRow>
          </TableHead>
          {exercises ? (
            <TableBody>
              {exercises.map((data) => (
                <TableRow key={data.id}>
                  <TableCell>{data.name}</TableCell>
                  <TableCell align="center">{data.muscleGroup}</TableCell>
                  <TableCell>
                    <Button
                      sx={{ maxWidth: 5 }}
                      color="error"
                      variant="contained"
                      onClick={() => onDelete(data.id)}
                    >
                      <DeleteIcon />
                    </Button>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          ) : (
            <Typography>Unable to get exercises</Typography>
          )}
        </Table>
      </TableContainer>
    </div>
  );
}
