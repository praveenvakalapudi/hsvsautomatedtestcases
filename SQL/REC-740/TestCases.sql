-- GET PATIENT
select * from patient where id=164445457

-- GET SPECIES TYPE FROM PATIENT ID
select vi_species_id as Species,* from patient p
inner join pms_species_lookup s on p.hid = s.hid and s.id = p.pms_species_id 
where p.id=164445457

-- TEST CASE BEGIN
-- SPECIES CHECK
-- PATIENT ID with 164445457 is on CAT TYPE
select * from campaign_targeting.patient_species_check(2882, 164445457,'{3,9}')  -- return false
select * from campaign_targeting.patient_species_check(2882, 164445457,'{7}')  -- return true


-- BREED CHECK
select * from campaign_targeting.species_breed_check(2882, 164445457,'{7}', '{1647942}')
select * from campaign_targeting.species_breed_check(2882, 164445457,'{7}', '{1647947,2669683,1652197}')

-- AGE RANGE CHECK
	-- IN MONTHS
	select age('2005-12-12'::date); -- which is "12 years 10 mons"
	Select * from campaign_targeting.patient_age_criteria_check(2882, 164445457, '1 month', '154 month');  -- true
	Select * from campaign_targeting.patient_age_criteria_check(2882, 164445457, '1 month', '153 month');  -- false
	
	-- IN YEARS
	Select * from campaign_targeting.patient_age_criteria_check(2882, 164445457, '1 year', '12 year');  -- true
	Select * from campaign_targeting.patient_age_criteria_check(2882, 164445457, '1 year', '11 year');  -- false

-- SPECIFIC AGE
	-- IN MONTHS
	Select * from campaign_targeting.patient_age_criteria_check(2882, 164445457, '154 month', '154 month');  -- true
	Select * from campaign_targeting.patient_age_criteria_check(2882, 164445457, '153 month', '153 month');  -- false
	
	-- IN YEARS
	Select * from campaign_targeting.patient_age_criteria_check(2882, 164445457, '12 year', '12 year');  -- true
	Select * from campaign_targeting.patient_age_criteria_check(2882, 164445457, '11 year', '11 year');  -- false


-- LAST VISIT
-- PATIENT ID VISITED on "2018-09-01"
select age('2018-09-01'::date)

select * from email.get_patient_by_last_visit(2882,164445457, null,null,null, false )

-- LAST VISIT IN DAYS
select * from email.get_patient_by_last_visit(2882,164445457, '1 day',null,null, false) -- false
select * from email.get_patient_by_last_visit(2882,164445457, '41 day',null,null, false) -- true

-- LAST VISIT IN MONTHS
select * from email.get_patient_by_last_visit(2882,164445457, '1 month',null,null, false) -- false
select * from email.get_patient_by_last_visit(2882,164445457, '2 month',null,null, false) -- true

-- LAST VISIT IN DAYS AND RANGE
select * from email.get_patient_by_last_visit(2882,164445457, '1 day','2018-09-02',CURRENT_DATE, false) -- false
select * from email.get_patient_by_last_visit(2882,164445457, '2 day','2018-09-01',CURRENT_DATE, false) -- true

-- LAST VISIT IN MONTH AND RANGE
select * from email.get_patient_by_last_visit(2882,164445457, '1 month','2018-09-02',CURRENT_DATE, false) -- false
select * from email.get_patient_by_last_visit(2882,164445457, '2 month','2018-09-01',CURRENT_DATE, false) -- true

-- LAST VISIT IN RANGE
select * from email.get_patient_by_last_visit(2882,164445457, null,'2018-09-02',CURRENT_DATE, false) -- false
select * from email.get_patient_by_last_visit(2882,164445457, null,'2018-09-01',CURRENT_DATE, false) -- true


-- INCLUSION LIST
-- GET LIST OF SERVICES FOR HID AND PATIENT
			select sl.id,* from patient p join tmplineitem_included_services li on p.id = li.patient_id and p.hid = li.hid
			join pms_service_lookup sl ON sl.id = li.pms_service_id  and sl.hid = li.hid
			join client c on c.id = li.client_id and c.hid = li.hid
			where p.id = 164445457 and p.hid = 2882
			
			

			
-- 	MATCH ANY SERVICE - TRUE
select * from email.get_patient_by_included_list(2882,164445457,true,'{25202410,25153625,25153576,53285157,25153624,26098532,26098532}', '12 year') --true
select * from email.get_patient_by_included_list(2882,164445457,true,'{25202410,25153625,25153576,53285157,25153624,26098532,26098532}', '1 year') -- false

-- MATCH ANY SERVICE - FALSE
select * from email.get_patient_by_included_list(2882,164445457,false,'{25202410,25153625,25153576,53285157,25153624,26098532,26098532}', '12 year') -- true
select * from email.get_patient_by_included_list(2882,164445457,false,'{25202410,25153625,25153576,53285157,25153624,26098532,26098532}', '1 year') -- false




-- EXCLUSION
-- 	MATCH ANY SERVICE - TRUE
select * from email.get_patient_by_excluded_list(2882,164445457,true,'{26098531}', '12 year') --true
select * from email.get_patient_by_excluded_list(2882,164445457,true,'{26098531}', '1 year') --false

-- 	MATCH ANY SERVICE - FALSE
select * from email.get_patient_by_excluded_list(2882,164445457,false,'{26098531}', '12 year') --true
select * from email.get_patient_by_excluded_list(2882,164445457,false,'{26098531}', '1 year') --false

select * from email.get_patient_by_excluded_list(2882,164445457,true,'{25202410,25153625,25153576,53285157,25153624,26098532,26098532}', '1 year') -- true





--





select * from email.get_patient_by_last_visit(2882,164445457, '1 day',null,null, false)
select * from email.get_patient_by_last_visit(2882,164445457, '1 day','2018-09-01','2018-10-12', false )




select count(distinct p.id) from patient p join lineitem li 
		on p.id = li.patient_id 
		and p.hid = li.hid
		where p.id = 164445457
		and ((li."date" between  current_date - '2 month'::interval and current_date) 
		or  (li.date between '2017-10-10' and '2018-10-11'))
		and  p.hid = 2882
		
		select * from lineitem where hid=2882 and patient_id=164445457 and id=2
		--"452:754"
		
		select * from pms_service_lookup
		--wh
		limit 1
		DROP TABLE IF EXISTS tmplineitem_included_services; 
CREATE TEMP Table tmplineitem_included_services on COMMIT PRESERVE ROWS
AS Select * from lineitem Where hid = 2882;
		
		select count(distinct p.id) 
			from patient p join tmplineitem_included_services li on p.id = li.patient_id and p.hid = li.hid
			join pms_service_lookup sl ON sl.id = li.pms_service_id  and sl.hid = li.hid
			join client c on c.id = li.client_id and c.hid = li.hid
			where p.id = in_patient_id
			and li."date"  between current_date - included_last_service::interval and current_date
			and p.hid = 2882
			group by p.id 
			having array_agg(sl.id) @> included_service_ids
		
			select sl.id,* from patient p join tmplineitem_included_services li on p.id = li.patient_id and p.hid = li.hid
			join pms_service_lookup sl ON sl.id = li.pms_service_id  and sl.hid = li.hid
			join client c on c.id = li.client_id and c.hid = li.hid
			where p.id = 164445457 and p.hid = 2882
			
		select * from pms_service_lookup
		where id=25202410
		



select * from pms_species_lookup --limit 10
where id=51969


select * from vi_species_lookup where id in (51969)
select * from vi_species_lookup limit 1
select * from vi_breed_lookup where id=1647942