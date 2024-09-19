import { createSlice } from "@reduxjs/toolkit";
import { listarSucursal, obtenerSucursal } from '../actions/actionSucursalA';

const initialState = {
  sucursales: [],
  sucursal: {},
  loading: false,
  error: null,
};

const SucursalASlice = createSlice({
  name: "sucursal",
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
      .addCase(obtenerSucursal.pending, (state) => {
        state.sucursal = {};
        state.loading = true;
        state.error = null;
      })
      .addCase(obtenerSucursal.fulfilled, (state, action) => {
        state.sucursal = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(obtenerSucursal.rejected, (state, action) => {
        state.sucursal = {};
        state.loading = false;
        state.error = action.error.message;
      });
  },
});

export const getSucursalAReducer = SucursalASlice.reducer;