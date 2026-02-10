pipeline {
  agent any

  stages {
    stage('Checkout') {
      steps {
          git 'https://github.com/Davidb2303/ProyectoFerreteria.git' 
      }
    }

    stage('Build') {
      steps {
        sh 'dotnet test --configuration Release'
      }
    }
  }
}
