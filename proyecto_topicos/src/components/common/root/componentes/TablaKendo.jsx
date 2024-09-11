import { orderBy } from "@progress/kendo-data-query";
import React, { useState } from "react";
import {
  Grid,
  GridColumn as Column,
  GridToolbar
} from '@progress/kendo-react-grid';

import { BotonEditar, BotonNuevo, BotonEliminar } from "./Botones";
import { style } from '../../../../constants/Constantes.js';

const initialDataState = {
    skip: 0,
    take: 10,
};

const TablaKendo = (
    {
        ordenamientoInicial,
        data,
        funcionNuevo,
        funcionEditar,
        funcionEliminar,
        estructuraTabla,
        verNuevo = true,
        verModificar = true,
        verEliminar = true,
        conAcciones = true
    }
) => {
    const [pagina, setPagina] = useState(initialDataState);
    const [ordenamiento, setOrdenamiento] = React.useState(ordenamientoInicial);
    const [tamanoPagina, setTamanoPagina] = useState();

    // Metodo de Paginacion
    const cambioPagina = (event) => {
        const targetEvent = event.targetEvent;
        const take =
            targetEvent.value === "All" ? data.length : event.page.take;
        if (targetEvent.value) {
            setTamanoPagina(targetEvent.value);
        }
        setPagina({
            ...event.page,
            take,
        });
    };

    return (
        <>
            <Grid
                sortable={true}
                sort={ordenamiento}
                onSortChange={(e) => {
                    setOrdenamiento(e.sort);
                }}
                data={orderBy(data.slice(pagina.skip, pagina.take + pagina.skip), ordenamiento)}
                skip={pagina.skip}
                take={pagina.take}
                total={data.length}
                pageable={{
                    buttonCount: 3,
                    pageSizes: [5, 10, 15, "All"],
                    pageSizeValue: tamanoPagina,
                }}
                onPageChange={cambioPagina}
            >
                <GridToolbar>
                    { verNuevo ? 
                        <BotonNuevo
                            accion={() => funcionNuevo()}
                        />
                    : null }
                    {/* Removed Export Buttons */}
                </GridToolbar>

                { estructuraTabla.columns.map((item) => (
                    <Column field={item.field} title={item.title} key={item.key} filter="text" filterCell={{ operator: "contains" }} cell={item.cell ? item.cell : null} />
                ))}
                
                { conAcciones ? 
    <Column field="Acciones" title="Acciones" width="120px" cell={({ dataItem }) => (
        <td style={style.acciones}>
            { verModificar ? 
                <BotonEditar
                    accion={() => funcionEditar(dataItem.idSucursal)} // Asegúrate de usar el id correcto
                />
            : null }
            
            { verEliminar ? 
                <BotonEliminar 
                    accion={() => funcionEliminar(dataItem.idSucursal)}  // Aquí también usa el id correcto
                />
            : null }
        </td>
    )}/>
: null}

            </Grid>
        </>
    );
}

export default TablaKendo;