import { createSlice } from "@reduxjs/toolkit";
import { listarSucursal, obtenerSurcursal } from '../actions/actionSucursal';

const initialState = {
  sucursales: [],
  sucursal: {},
  loading: false,
  error: null,
};

const SucursalSlice = createSlice({
  name: "getSucursal",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(listarSucursal.pending, (state) => {
        state.sucursales = [];
        state.loading = true;
        state.error = null;
      })
      .addCase(listarSucursal.fulfilled, (state, action) => {
        state.sucursales = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(listarSucursal.rejected, (state, action) => {
        state.sucursales = [];
        state.loading = false;
        state.error = action.error.message;
      })
      .addCase(obtenerSurcursal.pending, (state) => {
        state.sucursal = {};
        state.loading = true;
        state.error = null;
      })
      .addCase(obtenerSurcursal.fulfilled, (state, action) => {
        state.sucursal = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(obtenerSurcursal.rejected, (state, action) => {
        state.sucursal = {};
        state.loading = false;
        state.error = action.error.message;
      });
  },
});

export const getSucursalReducer = SucursalSlice.reducer;