<template>
<div>
    <p>Simple CRUD</p>
  <div class="home">
    <div class="form">
      <h3>Agregar permiso</h3>
      <label for="fname">Name:</label><br />
      <input type="text" v-model="myEntityModel.name" /><br /><br />
      <label for="lname">LastName:</label><br />
      <input type="text" v-model="myEntityModel.lastName" /><br /><br />
      <label for="lname">PermissionType:</label><br />
      <input
        type="text"
        v-model="myEntityModel.permissionType.description"
      /><br /><br />
      <label for="lname">datePermission:</label><br />
      <input type="date" v-model="myEntityModel.datePermission" /><br /><br />
      <button @click="add()">Agregar</button>
    </div>

    <div class="card">
        <div>
            <h3>Lista de Usuarios</h3>
        </div>
        <div>
            <table class="my-table">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>LastName</th>
                        <th>PermissionType</th>
                        <th>datePermission</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(entity, index) in myEntities" :key="index">
                        <td>{{ entity.name }}</td>
                        <td>{{ entity.lastName }}</td>
                        <td>{{ entity.permissionType.description }}</td>
                        <td>{{ entity.datePermission.split("T")[0] }}</td>
                        <td>
                            <router-link :to="{ path: '/about/'+ entity.id}"><button>Editar</button></router-link>
                            <button @click="deleteEntity(entity.id)">Eliminar</button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
  </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import HelloWorld from "@/components/HelloWorld.vue"; // @ is an alias to /src
import axios from "axios";

@Component({
  components: {
    HelloWorld,
  },
})
export default class HomeView extends Vue {
  myEntityModel: Permissions = new Permissions();
  myEntities: Permissions[] = [];

  async created() {
    var result = await axios.get<Permissions[]>(
      "https://localhost:44394/api/Permissions"
    );
    this.myEntities = result.data;
  }

  async add() {
    var result = await axios.post<Permissions>(
      "https://localhost:44394/api/Permissions",
      this.myEntityModel
    );
    location.reload();
    console.log(result);
  }
  async deleteEntity(id: number) {
    var result = await axios.delete<Permissions>(
      "https://localhost:44394/api/Permissions/" + id
    );
    location.reload();
    console.log(result);
  }
}

class Permissions {
  name: string = "";
  lastName: string = "";
  permissionType: PermissionType = new PermissionType();
  datePermission?: Date;
}

class PermissionType {
  description: string = "";
}
</script>

<style>
.my-table {
  width: 100%;
}
table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 90%;
}

td,
th {
  border: 1px solid #dddddd;
  padding: 8px;
}

tr:nth-child(even) {
  background-color: #dddddd;
}

.home {
  display: flex;
  flex-direction: row;
  align-items: center;

}

.form {
  padding: 5px 6rem 5px 6rem;
  border-radius: 10px;
  background: #ccc;
  color: black;
}

.form label {
  font-size: 1.2rem;
}

.form input {
  font-size: 1.2rem;
  padding: 0.5rem;
  margin-bottom: 0.5rem;
}

.form button {
  font-size: 1.2rem;
  padding: 0.5rem 5rem;
  margin-bottom: 0.5rem;
}

.card {
  padding: 6rem;
  border-radius: 10px;
  width: 80%;
  margin-left: auto;
  margin-right: auto;
}
</style>
