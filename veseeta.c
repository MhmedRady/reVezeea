departments 
{
	Id, name_en, name_ar, Created_at?, updated_at?
	1, "Hospital", "مستشفي", 2022-12-10 00:00:00,
	1, "Clinic", "عيادة", 2022-12-10 00:00:00,
}

/* departments_translate {
	1, ar, 1, ع,
	2, en, 1, c,
	3, ar, 2, م,
	4, en, 2, h,
	5, fr, 1, fr_h,
} */

centers 
{
	Id, Department_Id, User_Id?, name_en, name_ar, logo,
	 email, mobile, phone, views, visitors, is_active,
	 Created_at?, updated_at?
}

specialties 
{
	id, Specialtie_Id?, name_en, name_ar, logo, is_active, Created_at?, updated_at?
	1, null ,"اسنان"
	2, 1 ," تجميل اسنان"
	3, 1 ," x اسنان"
}

center_specialties 
{
	Id, Specialtie_Id, Center_Id, Created_at?, updated_at?
	1, "اسنان", "1"
	1, 2, 1
}

users 
{
	Id, firstName, middleName, lastName, email, password, mobile?, profile_image?, N_ID?
	is_admin, is_doctor, Created_at?, updated_at?
}

/** ADDRESS **/
states 
{
	Id, name_ar, name_en, 
}

cities 
{
	Id, State_Id, name_ar, name_en, 
}

addresses 
{
	Id, User_Id?, Center_Id?, is_active, State_Id, City_Id, 
	mobile?, phone?, address, lat, lng, Created_at?, updated_at?
}
/** END ADDRESS **/

comments
{
	Id, User_Id, Doctor_Id?, Center_Id?, content, rate, Created_at?, updated_at?
}

tags 
{
	Id, name_ar, name_en, icon, Created_at?, updated_at?
}

doctor_tags
{
	Id, User_Id, Tag_Id, Created_at?, updated_at?
}

reste_password
{
	Id, email, code, token, Created_at?
}

/** ROLES **/
permissions.groups
{
	Id, name, is_active, Created_at?, updated_at?
	1 	admin 	true 	2022-12-05, 2022-12-05
}

roles
{
	Id, 	name, 	group_id, 	Created_at?, 	updated_at?
	1 		admin 		1 		2022-12-05, 	2022-12-05
	2 		cust_ser 	1 		2022-12-05, 	2022-12-05
	3 		x 			1 		2022-12-05, 	2022-12-05
}

permissions
{
	Id, 	name, 	group_id,	created_at?, 	updated_at?
	1 	view_admin 		1  		NULL 		NULL 
	2 	create_admin  	1  		NULL 		NULL 
	2 	update_admin  	1  		NULL 		NULL 
	2 	delete_admin  	1  		NULL 		NULL 
	5	add_doctor		1		
}

permissions_roles
{
	Id, Role_Id, Permission_Id, created_at?, updated_at?
	1 		1 		1  		NULL 		NULL 
	2 		1 		2  		NULL 		NULL 
	3 		2 		1  		NULL 		NULL 
}
/** END ROLES **/

/** CHECKIN **/
wishlist 
{
	Id, User_Id, Center_Id?, Doctor_Id?, Created_at?
}

calendars
{
	Id, Doctor_Id?, date:Date, From:Time, To:Time, Created_at?, updated_at?
	// OR
	Id, Doctor_Id?, Day:int, Month:int, year:int, From:Time, To:Time, Created_at?, updated_at?
}

checkin 
{
	Id, User_Id, Center_Id?, Doctor_Id?, Comment_Id, checkin_at, amount, Created_at?, updated_at?
}
/** END CHECKIN **/

queue_jobs 
{
	Id,	queue,	payload, attempts, reserved_at, available_at, created_at
}

failed_jobs 
{
	Id,	uuid, connection, queue, payload, exception, failed_at 
}
