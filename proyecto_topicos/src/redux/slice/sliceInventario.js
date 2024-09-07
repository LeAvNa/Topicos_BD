import { createSlice } from "@reduxjs/toolkit";
import { listarInventario, obtenerInventario } from '../actions/actionInventario';

const initialState = {
  inventarios: [],
  inventario: {},
  loading: false,
  error: null,
};

const InventarioSlice = createSlice({
  name: "getInventario",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(listarInventario.pending, (state) => {
        state.inventarios = [];
        state.loading = true;
        state.error = null;
      })
      .addCase(listarInventario.fulfilled, (state, action) => {
        state.inventarios = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(listarInventario.rejected, (state, action) => {
        state.inventarios = [];
        state.loading = false;
        state.error = action.error.message;
      })
      .addCase(obtenerInventario.pending, (state) => {
        state.inventario = {};
        state.loading = true;
        state.error = null;
      })
      .addCase(obtenerInventario.fulfilled, (state, action) => {
        state.inventario = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(obtenerInventario.rejected, (state, action) => {
        state.inventario = {};
        state.loading = false;
        state.error = action.error.message;
      });
  },
});

export const getInventarioReducer = InventarioSlice.reducer;