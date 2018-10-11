-- Execute the function with following parameter values

select * from email.get_targated_audience
(
	2882, 				-- in_hid
	3, 					-- in_editor_verion_id
	82904,				-- in_marketing_msg_id
	'{3}',  			-- in_species_ids
	false,  			-- is_other_spacies
	false,  			-- is_all_breed
	'{}',   			-- in_breed_ids
	false,  			-- in_is_age_in_range
	null,   			-- in_specific_age
	null,   			-- in_age_range_from
	null,   			-- in_age_range_to
	null,   			-- in_last_service
	null,   			-- in_last_service_from
	null,   			-- in_last_service_to
	'{25153576}', 		-- in_included_service_ids
	false,  			-- in_match_any_included_service
	false,  			-- in_match_any_excluded_service
	'12 Months', 		-- in_included_last_service
	'{134218565}', 		-- in_excluded_service_ids
	'10 years' 			-- in_excluded_last_service
);
select * from pms_species_lookup
select * from email.get_patient_by_species_and_breed(2882, '{3}', false, '{}', false)
select * from patient p where p.id = 
	any(email.get_patient_by_species_and_breed(2882, '{3}', false, '{}', false))
											   and p.hid = 2882;
select * from patient p where p.id = 
	any(email.get_patient_by_species_and_breed(in_hid, in_species_ids, is_other_spacies, in_breed_ids, is_all_breed))
											   and p.hid = in_hid;