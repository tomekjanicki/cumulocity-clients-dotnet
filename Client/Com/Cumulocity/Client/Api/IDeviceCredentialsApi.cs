///
/// IDeviceCredentialsApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Com.Cumulocity.Client.Model;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary> 
	/// API methods to create device credentials in Cumulocity IoT. <br />
	/// Device credentials can be enquired by devices that do not have credentials for accessing a tenant yet.Since the device does not have credentials yet, a set of fixed credentials is used for this API.The credentials can be obtained by <see href="https://cumulocity.com/guides/about-doc/contacting-support/" langword="contacting support" />. <br />
	/// ⚠️ Important: Do not use your tenant credentials with this API. <br />
	/// ⓘ Info: The Accept header should be provided in all POST requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public interface IDeviceCredentialsApi
	{
	
		/// <summary> 
		/// Create device credentials <br />
		/// Create device credentials. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_DEVICE_BOOTSTRAP 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 200 Device credentials were created. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<DeviceCredentials?> CreateDeviceCredentials(DeviceCredentials body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
		
		/// <summary> 
		/// Create a bulk device credentials request <br />
		/// Create a bulk device credentials request. <br />
		/// Device credentials and basic device representation can be provided within a CSV file which must be UTF-8 or ANSI encoded. The CSV file must have two sections. <br />
		/// The first section is the first line of the CSV file. This line contains column names (headers): <br />
		/// |Name|Mandatory|Description||--- |--- |--- ||ID|Yes|The external ID of a device.||CREDENTIALS|Yes*|Password for the device's user. Mandatory, unless AUTH_TYPE is "CERTIFICATES", then CREDENTIALS can be skipped.||AUTH_TYPE|No|Required authentication type for the device's user. If the device uses credentials, this can be skipped or filled with "BASIC". Devices that use certificates must set "CERTIFICATES".||TENANT|No|The ID of the tenant for which the registration is executed (only allowed for the management tenant).||TYPE|No|The type of the device representation.||NAME|No|The name of the device representation.||ICCID|No|The ICCID of the device (SIM card number). If the ICCID appears in file, the import adds a fragment <c>c8y_Mobile.iccid</c>. The ICCID value is not mandatory for each row, see the example for an HTTP request below.||IDTYPE|No|The type of the external ID. If IDTYPE doesn't appear in the file, the default value is used. The default value is <c>c8y_Serial</c>. The IDTYPE value is not mandatory for each row, see the example for an HTTP request below.||PATH|No|The path in the groups hierarchy where the device is added. PATH contains the name of each group separated by <c>/</c>, that is: <c>main_group/sub_group/.../last_sub_group</c>. If a group does not exist, the import creates the group.||SHELL|No|If this column contains a value of 1, the import adds the SHELL feature to the device (specifically the <c>c8y_SupportedOperations</c> fragment). The SHELL value is not mandatory for each row, see the example for an HTTP request below.| <br />
		/// Section two is the rest of the CSV file. Section two contains the device information. The order and quantity of the values must be the same as of the headers. <br />
		/// A separator is automatically obtained from the CSV file. Valid separator values are: <c>\t</c> (tabulation mark), <c>;</c> (semicolon) and <c>,</c> (comma). <br />
		/// ⚠️ Important: The CSV file needs the "com_cumulocity_model_Agent.active" header with a value of "true" to be added to the request. <br />
		/// ⓘ Info: A bulk registration creates an elementary representation of the device. Then, the device needs to update it to a full representation with its own status. The device is ready to use only after it is updated to the full representation. Also see <see href="https://cumulocity.com/guides/users-guide/device-management/#creds-upload" langword="credentials upload" /> and <see href="https://cumulocity.com/guides/device-sdk/rest/#device-integration" langword="device integration" />. <br />
		/// A CSV file can appear in many forms (with regard to the optional tenant column and the occurrence of device information): <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>If a user is logged in as the management tenant, then the columns ID, CREDENTIALS and TENANT are mandatory, and the device credentials will be created for the tenant mentioned in the TENANT column. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>If a user is logged in as a different tenant, for example, as <c>sample_tenant</c>, then the columns ID and CREDENTIALS are mandatory (if the file contains the TENANT column, it is ignored and the device credentials will be created for the tenant that is logged in). <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>If a user wants to add information about the device, the columns TYPE and NAME must appear in the CSV file. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>If a user wants to add information about a SIM card number, the columns TYPE, NAME and ICCID must appear in the CSV file. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>If a user wants to change the type of external ID, the columns TYPE, NAME and IDTYPE must appear in the CSV file. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>If a user wants to add a device to a group, the columns TYPE, NAME and PATH must appear in the CSV file. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>If a user wants to add the SHELL feature, the columns TYPE, NAME and SHELL must appear in the CSV file and the column SHELL must contain a value of 1. <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// It is possible to define a custom <see href="#tag/External-IDs" langword="external ID" /> mapping and some custom device properties which are added to newly created devices during registration: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>To add a custom external ID mapping, enter the external ID type as the header of the last column with the prefix "external-", for example, to add an external ID mapping of type <c>c8y_Imei</c>, enter <c>external-c8y_Imei</c> in the last column header. The value of this external ID type should be set in the corresponding column of the data rows. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>To add a custom property to a registered device, enter the custom property name as a header, for example, "myCustomProperty", and the value would be in the rows below. <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// The custom device properties mapping has the following limitations: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>Braces '{}' used in data rows will be interpreted as strings of "{}". The system will interpret the value as an object when some custom property is added, for example, put <c>com_cumulocity_model_Agent.active</c> into the headers row and <c>true</c> into the data row to create an object <c>"com_cumulocity_model_Agent": {"active": "true"}"</c>. <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>It is not possible to add array values via bulk registration. <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// Example file: <br />
		/// <![CDATA[
		/// ID;CREDENTIALS;TYPE;NAME;ICCID;IDTYPE;PATH;SHELL
		/// id_101;AbcD1234!1234AbcD;type_of_device;Device 101;111111111;;csv device/subgroup0;1
		/// id_102;AbcD1234!1234AbcD;type_of_device;Device 102;222222222;;csv device/subgroup0;0
		/// id_111;AbcD1234!1234AbcD;type_of_device;Device 111;333333333;c8y_Imei;csv device1/subgroup1;0
		/// id_112;AbcD1234!1234AbcD;type_of_device;Device 112;444444444;;csv device1/subgroup1;1
		/// id_121;AbcD1234!1234AbcD;type_of_device;Device 121;555555555;;csv device1/subgroup2;1
		/// id_122;AbcD1234!1234AbcD;type_of_device;Device 122;;;csv device1/subgroup2;
		/// id_131;AbcD1234!1234AbcD;type_of_device;Device 131;;;csv device1/subgroup3;
		/// ]]>
		/// There is also a simple registration method that creates all registration requests at once, then each one needs to go through regular acceptance.This simple registration only makes use of the ID and PATH fields from the list above. <br />
		/// 
		/// <br /> Required roles <br />
		///  ROLE_DEVICE_CONTROL_ADMIN 
		/// 
		/// <br /> Response Codes <br />
		/// The following table gives an overview of the possible response codes and their meanings: <br />
		/// <list type="bullet">
		/// 	<item>
		/// 		<description>HTTP 201 A bulk of new device requests was created. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// 	<item>
		/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
		/// 		</description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="file">The CSV file to be uploaded. <br /></param>
		/// <param name="xCumulocityProcessingMode">Used to explicitly control the processing mode of the request. See <see href="#processing-mode" langword="Processing mode" /> for more details. <br /></param>
		/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
		///
		Task<BulkNewDeviceRequest?> CreateBulkDeviceCredentials(byte[] file, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) ;
	}
	#nullable disable
}
