import { Link } from 'react-router-dom';
import React from 'react';

function MenuItem({ path, label, icon, isActive, onClick }) {
  return (
    <div className={`menu-item ${isActive ? 'active' : ''}`}>
      <Link to={path} className="menu-link" onClick={() => onClick(label)}>
        <span className="menu-icon"><i className={`mdi ${icon}`}></i></span>
        <span className="menu-text">{label}</span>
      </Link>
    </div>
  );
}

export default MenuItem;