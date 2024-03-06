import React, { useEffect } from "react";
import {
  Table,
  TableContainer,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
} from "@mui/material";

export default function ExercisesTable({ exercises }) {
  return (
    <div>
      <TableContainer>
        <Table sx={{ minWidth: 350 }}>
          <TableHead>
            <TableRow>
              <TableCell>Name </TableCell>
              <TableCell align="right">Muscle Group </TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {exercises.map((data) => (
              <TableRow key={data.id}>
                <TableCell>{data.name}</TableCell>
                <TableCell align="right">{data.muscleGroup}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </div>
  );
}
