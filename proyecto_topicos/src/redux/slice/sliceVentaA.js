import { createSlice } from "@reduxjs/toolkit";
import { listarVenta, obtenerVenta } from '../actions/actionVentaA';

const initialState = {
  ventas: [],
  venta: {},
  loading: false,
  error: null,
};

const VentaASlice = createSlice({
  name: "getVenta",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(listarVenta.pending, (state) => {
        state.ventas = [];
        state.loading = true;
        state.error = null;
      })
      .addCase(listarVenta.fulfilled, (state, action) => {
        state.ventas = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(listarVenta.rejected, (state, action) => {
        state.ventas = [];
        state.loading = false;
        state.error = action.error.message;
      })
      .addCase(obtenerVenta.pending, (state) => {
        state.venta = {};
        state.loading = true;
        state.error = null;
      })
      .addCase(obtenerVenta.fulfilled, (state, action) => {
        state.venta = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(obtenerVenta.rejected, (state, action) => {
        state.venta = {};
        state.loading = false;
        state.error = action.error.message;
      });
  },
});

export const getVentaAReducer = VentaASlice.reducer;