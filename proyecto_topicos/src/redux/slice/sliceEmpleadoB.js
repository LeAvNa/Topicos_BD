import { createSlice } from "@reduxjs/toolkit";
import { listarEmpleado, obtenerEmpleado } from '../actions/actionEmpleadoB';

const initialState = {
  empleados: [],
  empleado: {},
  loading: false,
  error: null,
};

const EmpleadoBSlice = createSlice({
  name: "getEmpleado",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(listarEmpleado.pending, (state) => {
        state.empleados = [];
        state.loading = true;
        state.error = null;
      })
      .addCase(listarEmpleado.fulfilled, (state, action) => {
        state.empleados = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(listarEmpleado.rejected, (state, action) => {
        state.empleados = [];
        state.loading = false;
        state.error = action.error.message;
      })
      .addCase(obtenerEmpleado.pending, (state) => {
        state.empleado = {};
        state.loading = true;
        state.error = null;
      })
      .addCase(obtenerEmpleado.fulfilled, (state, action) => {
        state.empleado = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(obtenerEmpleado.rejected, (state, action) => {
        state.empleado = {};
        state.loading = false;
        state.error = action.error.message;
      });
  },
});

export const getEmpleadoBReducer = EmpleadoBSlice.reducer;