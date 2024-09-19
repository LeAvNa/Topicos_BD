import { createSlice } from "@reduxjs/toolkit";
import { listarCliente, obtenerCliente } from '../actions/actionClienteB';

const initialState = {
  clientes: [],
  cliente: {},
  loading: false,
  error: null,
};

const ClienteBSlice = createSlice({
  name: "getCliente",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(listarCliente.pending, (state) => {
        state.clientes = [];
        state.loading = true;
        state.error = null;
      })
      .addCase(listarCliente.fulfilled, (state, action) => {
        state.clientes = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(listarCliente.rejected, (state, action) => {
        state.clientes = [];
        state.loading = false;
        state.error = action.error.message;
      })
      .addCase(obtenerCliente.pending, (state) => {
        state.cliente = {};
        state.loading = true;
        state.error = null;
      })
      .addCase(obtenerCliente.fulfilled, (state, action) => {
        state.cliente = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(obtenerCliente.rejected, (state, action) => {
        state.cliente = {};
        state.loading = false;
        state.error = action.error.message;
      });
  },
});

export const getClienteBReducer = ClienteBSlice.reducer;