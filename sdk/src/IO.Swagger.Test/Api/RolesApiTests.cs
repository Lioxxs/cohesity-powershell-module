/* 
 * Cohesity REST API
 *
 * This API provides operations for interfacing with the Cohesity Cluster. NOTE: To view the documentation on the responses, click 'Model' next to 'Example Value' and keep clicking to expand the hierarchy.
 *
 * OpenAPI spec version: 1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace IO.Swagger.Test
{
    /// <summary>
    ///  Class for testing RolesApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class RolesApiTests
    {
        private RolesApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new RolesApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of RolesApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' RolesApi
            //Assert.IsInstanceOfType(typeof(RolesApi), instance, "instance is a RolesApi");
        }

        
        /// <summary>
        /// Test CreateRole
        /// </summary>
        [Test]
        public void CreateRoleTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //RoleCreateParameters body = null;
            //var response = instance.CreateRole(body);
            //Assert.IsInstanceOf<Role> (response, "response is Role");
        }
        
        /// <summary>
        /// Test DeleteRoles
        /// </summary>
        [Test]
        public void DeleteRolesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //RoleDeleteParameters body = null;
            //instance.DeleteRoles(body);
            
        }
        
        /// <summary>
        /// Test GetRoles
        /// </summary>
        [Test]
        public void GetRolesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string name = null;
            //var response = instance.GetRoles(name);
            //Assert.IsInstanceOf<List<Role>> (response, "response is List<Role>");
        }
        
        /// <summary>
        /// Test UpdateRole
        /// </summary>
        [Test]
        public void UpdateRoleTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string name = null;
            //RoleUpdateParameters body = null;
            //var response = instance.UpdateRole(name, body);
            //Assert.IsInstanceOf<Role> (response, "response is Role");
        }
        
    }

}
