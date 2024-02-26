import { Box, Container, Typography } from "@mui/material";
import React from "react";

export default function Heading({ headingTitle }) {
  return (
    <div>
      <Box
        sx={{
          height: "15vh",
          backgroundColor: "#34b7eb",
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <Typography fontSize={48} color={"white"}>
          {headingTitle}
        </Typography>
      </Box>
    </div>
  );
}
