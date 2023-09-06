import React, { Fragment, useEffect, useState } from "react";

import { Card } from "primereact/card";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { Button } from "primereact/button";

import getProducts from "../web/getService";
import { Link } from "react-router-dom";

const ActionsTemplate = (rowData) => {
  return (
    <Fragment>
      <Link to={`producto/${rowData.id}`} state={{ producto: rowData }}>
        <Button label="Ver" />
      </Link>
    </Fragment>
  );
};

export default function Dashboard() {
  const [productos, setProductos] = useState(estadoInicial);

  useEffect(() => {
    getProducts().then((res) => setProductos(res.data));
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
        <Column body={ActionsTemplate} />
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

const productoEjemplo = {
  nombre: "El sorprendente hombre araña #1",
  precio: 8,
  existencia: 5,
  genero: "Acción, Super Heroes",
  fabricante: "Marvel Comics",
  proveedor: "Televisa",
  tipo: "Comic",
};

const estadoInicial = [productoEjemplo];
