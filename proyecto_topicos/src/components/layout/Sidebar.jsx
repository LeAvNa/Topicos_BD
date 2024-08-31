import React from "react";
import {
  CDBSidebar,
  CDBSidebarContent,
  CDBSidebarFooter,
  CDBSidebarHeader,
  CDBSidebarMenu,
  CDBSidebarMenuItem,
} from "cdbreact";
import { NavLink } from "react-router-dom";
import { EstructuraMenu } from "../../constants/EstructuraMenu"; // Asegúrate de importar correctamente

const Sidebar = () => {
  // Obtenemos las claves de las categorías principales del menú
  const menuKeys = EstructuraMenu ? Object.keys(EstructuraMenu) : [];

  return (
    <CDBSidebar textColor="#fff" backgroundColor="#333">
      <CDBSidebarHeader prefix={<i className="fa fa-bars fa-large"></i>}>
        <a href="/" className="text-decoration-none" style={{ color: "inherit" }}>
          Tópicos
        </a>
      </CDBSidebarHeader>

      <CDBSidebarContent className="sidebar-content">
        <CDBSidebarMenu>
          {/* Iteramos sobre las categorías principales de EstructuraMenu */}
          {menuKeys.map((categoryKey) => {
            const category = EstructuraMenu[categoryKey]; // Obtenemos la categoría actual

            return (
              <React.Fragment key={categoryKey}>
                {/* Renderizamos el encabezado del menú */}
                <div className="menu-header">
                  <span className="menu-text">{category.etiqueta}</span>
                </div>

                {/* Iteramos sobre los elementos del submenú */}
                {category.items?.map((item, index) => (
                  <NavLink
                    key={index}
                    exact
                    to={item.Path}
                    activeClassName="activeClicked"
                  >
                    <CDBSidebarMenuItem icon={item.icon}>
                      {item.etiqueta}
                    </CDBSidebarMenuItem>
                  </NavLink>
                ))}

                {/* Separador entre los diferentes menús */}
                <div className="menu-divider"></div>
              </React.Fragment>
            );
          })}
        </CDBSidebarMenu>
      </CDBSidebarContent>

      <CDBSidebarFooter style={{ textAlign: "center" }}>
        <div style={{ padding: "20px 5px" }}>
          {/* Aquí puedes agregar cualquier contenido adicional para el footer */}
        </div>
      </CDBSidebarFooter>
    </CDBSidebar>
  );
};

export default Sidebar;