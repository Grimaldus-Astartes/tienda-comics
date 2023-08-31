import React, { useEffect, useState } from "react";

import { Card } from "primereact/card";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { Button } from "primereact/button";

import getProducts from '../web/getService'


export default function Dashboard() {
  const [productos, setProductos] = useState([]);
  useEffect(() => {
    getProducts()
      .then((res) => setProductos(res.data));
  }, [productos]);
  
  return (
    <Card>
      <DataTable value={productos}>
        {columns.map((column, index) => (
          <Column
            key={column.field}
            field={column.field}
            header={column.header}
          />
        ))}
        <Column key="actions" header="Acciones" body={<Button label="Ver" />} />
      </DataTable>
    </Card>
  );
}

const columns = [
  { field: "nombre", header: "Nombre" },
  { field: "tipo", header: "Tipo" },
  { field: "precio", header: "Precio" },
  { field: "existencia", header: "Existencia" },
];
